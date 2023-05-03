using System;
using System.Linq;
using System.Threading.Tasks;
using CommaBoard.Store.Class;
using CommaBoard.Store.Interface;
using CommaBoard.Store.Library;
using CommaBoard.Store.Static;
using MvvmCross;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Timers;
using System.Collections.Generic;

namespace CommaBoard.Core.Models
{
    public class WaveDataSentModel : IDataSentModel
    {
        #region     Private Fields

        ICommaBoardButton cbButton = Mvx.IoCProvider.Resolve<ICommaBoardButton>();

        ICBClient cbClient = Mvx.IoCProvider.Resolve<ICBClient>();

        bool dataSentOK = false;

        string numberString = "";

        bool errorFound = false;

        System.Timers.Timer shortcutTimer;

        string shortcutString = "";

        WindowHandling windowHandling = new WindowHandling();

        ICommaBoardButton buttonPassedIn = new CommaBoardButton();

        #endregion

        #region     Public Properties

        public string Status { get; set; }
        public bool StatusError { get; set; }
        public int CurrentNumber { get; set; }
        public bool WithNumber { get; set; }

        #endregion

        #region     Constructor

        public WaveDataSentModel()
        {
            Initialise();
        }

        #endregion

        #region     Initialise Methods

        /// <summary>
        /// Initialise Model settings
        /// </summary>
        void Initialise()
        {
            //  Nothing to Initialise currently
        }

        #endregion

        #region     Public Methods

        /// <summary>
        /// Send button byte array
        /// </summary>
        public void Send_ButtonData()
        {
            HandleButtonOutput();
        }

        #endregion

        #region     Private Methods

        /// <summary>
        /// Splits the button calls between Command buttons and Settings buttons
        /// </summary>
        void HandleButtonOutput()
        {
            try
            {
                //    Set the button passed in
                buttonPassedIn = CommaBoardButton.BufferButtonList.First();

                //  Is there a green command button involved?
                if (CommaBoardButton.GreenCommandButton != null)
                {
                    switch (CommaBoardButton.GreenCommandButton.Name)
                    {
                        case "Layout":
                            CommandChangeSelectedLayout();
                            break;

                        case "Camera":
                            //  Bail out if the Camera Logical ID selected is not present
                            Camera cam = Wave.Grid.CameraControlCameraList.Where(c => c.logicalId == Display.Numbers.NumberDisplayNumber.ToString()).FirstOrDefault();
                            if(cam == null)
                            {
                                //	Display warning that no Camera Logical Id
                                ViewDisplay.DisplayViewWarningMessage("No Logical Id number has been found for the camera selected");

                                return;
                            }

                            //  Hold the Logical Id of the current selected Layout
                            int temp = Wave.Grid.CurrentLayoutLogicalId;

                            //  Carry out the change
                            CommandChangeCameraInLayoutData();

                            //  Now reload the selected Layout from the temp integer
                            Wave.Grid.CurrentLayoutLogicalId = temp;

                            Wave.Grid.UpdateSelectedLayout();

                            break;
                    }

                    //  Null the Green Command Button to prevent shortcut key
                    //  command straying into the last Command Button action
                    CommaBoardButton.GreenCommandButton = null; 

                    return;
                }

                //  Is this a shortcut key command button
                if (buttonPassedIn.Name.IndexOf("sc_") != -1)
                {
                    SendKeyboardShortcutCommandToWaveClient(buttonPassedIn.Name);

                    return;
                }

                //  Must be a settings button 
                switch (buttonPassedIn.Name)
                {

                    case "RefreshCameras":
                        SettingsLoadAvailableCameras();
                        break;

                    case "RefreshLayouts":
                        SettingsLoadAvailableLayouts();
                        break;

                    case "RefreshUsers":
                        SettingsLoadAvailableUsers();
                        break;

                }

            }
            catch (Exception ex)
            {
                //  Log and display the exception error
                Utilities.LogAndDisplayError(ex, $"Error processing button {buttonPassedIn.Name}");
            }
        }

        #region     Command Button Methods

        /// <summary>
        /// Change the Selected Layout and then the Selected Camera
        /// </summary>
        void CommandChangeSelectedLayout()
        {
            try
            {
                //  Bail out if there are no Layouts in the list
                if (Wave.Grid.LayoutControlLayoutList == null || Wave.Grid.LayoutControlLayoutList.Count < 1) return;

                //  Use a dummy Layout to test the number selected is correct
                Layout templayout = Wave.Grid.LayoutControlLayoutList.Where(l => l.logicalId == int.Parse(Display.Numbers.NumberBuffer)).FirstOrDefault();

                //  Bail out if no such Layout
                if(templayout == null)
                {
                    //	Log and display problem message
                    

                    return;
                }

                //  All OK so change the selected Layout
                Wave.Grid.LayoutControlSelectedLayout = templayout;

                //  Update the display
                Display.Numbers.NumberDisplayLayout = int.Parse(Display.Numbers.NumberBuffer);

                //  Change the selected camera to the first one in the new Layout


                //	Log and display success message


            }
            catch (Exception ex)
            {
                //  Log and display the exception error
                
            }

        }

        /// <summary>
        /// Use the Camera Command button to change the Selected Camera in the Selected Layout
        /// </summary>
        async void CommandChangeCameraInLayoutData()
        {
            try
            {
                //  Choose one step or two step method
                await CommandSupportChangeCameraInLayout_2Step();

                //  await CommandSupportChangeCameraInLayout_1Step();

                //  Refresh the available layouts list
                SettingsLoadAvailableLayouts();

                //	Log and display success message
                

            }
            catch (Exception ex)
            {
                //  Log and display the exception error
               
            }
        }

        #endregion

        #region     Command Button Support Methods

        /// <summary>
        /// Change the Selected Camera in the Selected Layout in one step
        /// without the need to empty the Layout first
        /// </summary>
        /// <returns></returns>
        //async Task<bool> CommandSupportChangeCameraInLayout_1Step()
        //{
        //    try
        //    {
        //        //  Overwrite the old Camera Guid ( resourceId ) with new Camera Guid
        //        if (!CommandSupportReplaceCameraGuidInSelectedLayoutItem()) return false;

        //        //  Serialize the SelectedLayout now with new Camera
        //        SerializeSaveLayoutCommand(Wave.Grid.LayoutControlSelectedLayout);

        //        //  Now send the HTTP command
        //        Task<string> taskchange = cbClient.SendHTTP();

        //        string taskresult = await taskchange;

        //        //  If there was an error bail out
        //        if (TaskReturnMessageErrorFound(taskresult)) return false;

        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// Change the Selected Camera in the Selected Layout in two steps
        /// First by emptying the layout and saving it, then refilling it 
        /// with the amended item(s)
        /// </summary>
        /// <returns></returns>
        async Task<bool> CommandSupportChangeCameraInLayout_2Step()
        {
            Camera oldCam = new Camera();
            Camera newCam = new Camera();

            try
            {
                #region     SWAP THE CAMERA GUIDS AND UPDATE RESOURCE ID

                //  Find the Camera that has been selected as replacement
                newCam = Wave.Grid.CameraControlCameraList.Where(c => c.logicalId == Display.Numbers.NumberBuffer).FirstOrDefault();

                //  Was the replacement camera found?
                if (newCam == null)
                {
                    //  Display the fact replacement camera cannot be found
                    ViewDisplay.DisplayViewWarningMessage(GeneralTextLibrary.CHANGE_CAMERA_OLD_CAMERA_NOT_FOUND);

                    return false;
                }

                //  Find the Layout Selected Camera ( the one to be replaced ) 
                oldCam = Wave.Grid.LayoutControlSelectedCamera;

                //  Was the camera to be replaced found?
                if (newCam == null || oldCam == null)
                {
                    //	Display the fact camera to be replaced could not be found
                    ViewDisplay.DisplayViewWarningMessage(GeneralTextLibrary.CHANGE_CAMERA_NEW_CAMERA_NOT_FOUND);

                    return false;
                }

                //  Now swap Resource Id
                Wave.Grid.LayoutControlSelectedLayout.items.Where(i => i.resourceId == oldCam.id).First().resourceId = newCam.id;

                //  Update the Current Camera Logical Id
                Wave.Grid.CurrentCameraLogicalId = int.Parse(newCam.logicalId);

                //	Log and display success message
                Log.InfoMessage($"Camera swap part one. Resource Id from {oldCam.name} swapped to Resource Id from {newCam.name}");

                #endregion

                #region     EMPTY THE LAYOUT OF ITEMS

                //  Save the current Layout Items
                Wave.SavedLayoutItems = Wave.Grid.LayoutControlSelectedLayout.items.ToList();

                //  Now empty all the Layout Items
                Wave.Grid.LayoutControlSelectedLayout.items = new LayoutItem[] { };

                //  Serialize the SelectedLayout now with no items
                SerializeSaveLayoutCommand(Wave.Grid.LayoutControlSelectedLayout);

                //  Now send the HTTP command
                Task<string> taskempty = cbClient.SendHTTP();

                string taskresult1 = await taskempty;

                //  If there was an error bail out
                if (TaskReturnMessageErrorFound(taskresult1)) return false;

                //	Log and display success message
                Log.InfoMessage($"Camera swap part two. Layout {Wave.Grid.LayoutControlSelectedLayout.name} emptied of items");

                #endregion

                #region     REFILL THE LAYOUT WITH AMENDED ITEMS

                //  Add all the saved Layout Items back into the selected Layout
                Wave.Grid.LayoutControlSelectedLayout.items = Wave.SavedLayoutItems.ToArray();

                //  Serialize the SelectedLayout with its items back ( including updated Camera guid )
                SerializeSaveLayoutCommand(Wave.Grid.LayoutControlSelectedLayout);

                //  Now send the HTTP command
                Task<string> taskrefill = cbClient.SendHTTP();

                string taskresult2 = await taskrefill;

                //  If there was an error bail out
                if (TaskReturnMessageErrorFound(taskresult2)) return false;

                //	Log and display success message
                Log.InfoMessage($"Camera swap part three. Layout {Wave.Grid.LayoutControlSelectedLayout.name} refilled with saved items, including swapped camera");
                ViewDisplay.DisplayViewInfoMessage("");

                return true;

                #endregion

            }
            catch (Exception ex)
            {
                //  Log and display the exception error
                Utilities.LogAndDisplayError(ex, $"Error in layout {Wave.Grid.LayoutControlSelectedLayout.name} changing {oldCam.name} for {newCam.name}");

                return false;
            }
        }

        #endregion

        #region     Settings Button Methods

        /// <summary>
        /// Run the getCamerasEx HTTP command to fill the Available Cameras datagrid
        /// </summary>
        async void SettingsLoadAvailableCameras()
        {
            try
            {
                //  Set the HTTP command string
                cbClient.ApiCommand = "ec2/getCamerasEx";

                Task<string> taskcameras = cbClient.GetCameraList();

                string taskresult = await taskcameras;

                if (taskresult.IndexOf("Error") != -1)
                {
                    //	Log and display problem message
                    Utilities.LogAndDisplayWarning(taskresult);
                }

                //	Log and display success message
                Utilities.LogAndDisplayInfo(GeneralTextLibrary.CAMERA_LIST_SUCCESSFULLY_REQUESTED);

            }
            catch (Exception ex)
            {
                //  Log and display the exception error
                Utilities.LogAndDisplayError(ex, GeneralTextLibrary.CAMERA_LIST_ERROR);
            }

        }

        /// <summary>
        /// Run the getLayouts HTTP command to fill the Available Layouts list
        /// </summary>
        async void SettingsLoadAvailableLayouts()
        {
            try
            {
                //  Set the HTTP command string
                cbClient.ApiCommand = "ec2/getLayouts";

                Task<string> tasklayouts = cbClient.GetLayoutList();

                string taskresult = await tasklayouts;

                if (taskresult.IndexOf("Error") != -1)
                {
                    //	Log and display problem message
                    Utilities.LogAndDisplayWarning(taskresult);

                    return;
                }

                //  If there are no Layouts bail out here
                if (Wave.Grid.LayoutControlLayoutList.Count == 0)
                {
                    //  Log and display no layouts
                    Utilities.LogAndDisplayWarning(GeneralTextLibrary.LAYOUT_LIST_NO_LAYOUTS_FOUND);

                    return;
                }

                //  If the Current Layout LogicalId is zero grab the first Layout in list
                if (Wave.Grid.CurrentLayoutLogicalId == 0) Wave.Grid.LayoutControlSelectedLayout = Wave.Grid.LayoutControlLayoutList.FirstOrDefault();

                //  If the Current Camera LogicalId is greater than zero find that Camera
                if (Wave.Grid.CurrentLayoutLogicalId > 0) Wave.Grid.LayoutControlSelectedLayout = Wave.Grid.LayoutControlLayoutList.Where(l => l.logicalId == Wave.Grid.CurrentLayoutLogicalId).FirstOrDefault();

                //  Log and display successful request of Layouts
                Utilities.LogAndDisplayInfo(GeneralTextLibrary.LAYOUT_LIST_SUCCESSFULLY_REQUESTED);
            }
            catch (Exception ex)
            {
                //  Log and display the exception error
                Utilities.LogAndDisplayError(ex, GeneralTextLibrary.LAYOUT_LIST_ERROR);
            }
        }

        #endregion

        #region     Shortcut Button Methods

        /// <summary>
        /// Using the button name send the appropriate shortcut command to the Wave client
        /// </summary>
        /// <param name="buttonname"></param>
        void SendKeyboardShortcutCommandToWaveClient(string buttonname)
        {
            try
            {
                if (buttonPassedIn.Name == "sc_CloseInfo")
                {
                    IDictionary<IntPtr, InfoWindow> dict = RunningWindows.GetOpenedWindows();

                    foreach (var d in dict)
                    {
                        if (d.Value.Title.IndexOf("Cameras List") != -1)
                        {
                            windowHandling.TargetWindowByHandle(d.Value.Handle);

                            MockKeyboard.SendKeyPress(MockKeyboard.KeyCode.ESC);

                            return;
                        }
                    }

                }

                if (buttonPassedIn.Name == "sc_Playback")
                {
                    shortcutString = "m"; SendShortcutCommand();
                    shortcutString = "z"; SendShortcutCommand();
                    shortcutString = "m"; SendShortcutCommand();

                    return;
                }

                //  Use the library method to obtain the actual command
                shortcutString = ShortcutLibrary.ReturnShortcutCommandFromButtonName(buttonPassedIn.Name);

                //  Not a timer key so just send command
                SendShortcutCommand();

                //	Display message
                ViewDisplay.DisplayViewInfoMessage($"Command sent for button {buttonPassedIn.Name}");

            }
            catch (Exception ex)
            {
                //  Log and display the exception error
                Utilities.LogAndDisplayError(ex, $"Error sending command for button {buttonPassedIn.Name}");
            }

        }

        void SendShortcutCommand()
        {
            try
            {
                //  Ensure Wisenet WAVE is the target application
               
                string result = windowHandling.BringMainWindowToFront();

               // windowHandling.BringApplicationToFrontAndSendKeyboardShortcut("OpsCenter", shortcutString);

                //  Bail out if an error occurred trying to put
                //  Wisenet WAVE as target application
                if(result.IndexOf("Error")!= -1)
                {
                    //	Log and display problem message
                    Utilities.LogAndDisplayWarning(GeneralTextLibrary.WINDOW_HANDLING_TARGET_ERROR);

                    return;
                }

                //  Send the shortcut command 
                SendKeys.SendWait(shortcutString);
            }
            catch (Exception ex)
            {
                //	Log message
                Utilities.LogAndDisplayError(ex, GeneralTextLibrary.WINDOW_HANDLING_TARGET_ERROR);
            }

        }

        #endregion

        #region     Private Serialize Methods

        /// <summary>
        /// Serialise data and set URI for SaveLayout request
        /// </summary>
        /// <param name="layout"></param>
        void SerializeSaveLayoutCommand(Layout layout)
        {
            //  We are using the Save layout command
            cbClient.ApiCommand = "ec2/saveLayout";

            //  Serialize the selected layout for the JSON message to be sent
            cbClient.ApiMessage = JsonConvert.SerializeObject(layout);
        }
       
        #endregion

        #region     Cryptlex Methods

        /// <summary>
        /// Using the Cryptlex API load available Users 
        /// working at this location
        /// </summary>
        async void SettingsLoadAvailableUsers()
        {
            try
            {



                //if (taskresult.IndexOf("Error") != -1)
                //{
                //    //  Error detected
                //    LogAndUpdateStatusProperties(null, taskresult, true);

                //    return;
                //}

                //LogAndUpdateStatusProperties(null, taskresult, false);

                

            }
            catch (Exception ex)
            {
                //  Log and display the exception error
                
            }
        }

        #endregion

        #region     Private Log And Status Methods

        /// <summary>
        /// If a Client Task has returned an error then display and return true
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool TaskReturnMessageErrorFound(string msg)
        {
            if (msg.IndexOf("Error") != -1)
            {
                //	Log and display problem message
                Utilities.LogAndDisplayWarning(msg);

                return true;
            }

            //	Log and display API Task successful
            Utilities.LogAndDisplayInfo(msg);

            return false;
        }

        #endregion

        #endregion

    }
}
