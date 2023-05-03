using System;
using CommaBoard.Store.Class;
using CommaBoard.Store.Interface;
using CommaBoard.Store.Static;
using MvvmCross;

namespace CommaBoard.Core.Models
{
    public class WaveCommaBoardButtonModel : ICommaBoardButtonModel
    {
        #region     Public Properties

        public bool DataSent { get; set; }

        #endregion

        #region     Private Fields

        ICommaBoardButton currentButton;

        IDataAccess dataAccess = Mvx.IoCProvider.Resolve<IDataAccess>();

        ICBClient cbClient = Mvx.IoCProvider.Resolve<ICBClient>();

        IDataSentModel dataSentModel = Mvx.IoCProvider.Resolve<IDataSentModel>();

        bool greenCommandButtonPressed = false;

        #endregion

        #region     Constructor

        public WaveCommaBoardButtonModel()
        { }

        #endregion

        #region     Public Methods

        /// <summary>
        /// Handle the button passed in from the ControlViewModel
        /// </summary>
        /// <param name="button"></param>
        public void HandleButtonPress(ICommaBoardButton button)
        {
            //  Assign the button passed in to the currentButton object and process it
            currentButton = button;

            HandleButtonPassedIn();
        }

        #endregion

        #region     Private Methods

        /// <summary>
        /// Process the button pressed and decide if any data needs sending
        /// </summary>
        void HandleButtonPassedIn()
        {

            //  Valid button?
            if (!ValidButtonPassedIn()) return;

            //  Client connected
            if (!CBClientConnected()) return;

            //  Any special button requirements
            HandleAnySpecialButtonRequirements();

            //  If this button does not send data then bail out here.
            if (!currentButton.SendData) return;

            //  Add the button name to the button press string
            AddButtonNameToButtonsPressedString();

            //  Add this button to the buffered Button List
            AddButtonToBufferList();

            //  Add any digit to the number display
            AddDigitToNumberDisplay();

            //  If this is a buffer button then return now
            if (currentButton.Buffer) return;

            //  Send the data for button(s) in the Button List
            dataSentModel.Send_ButtonData();

            //  Clear the green button flag
            greenCommandButtonPressed = false;

            //  Clean up after data sent whatever the outcome
            ClearBufferedButtonList();
        }

        /// <summary>
        /// Check if this is a valid button object ( not null )
        /// </summary>
        /// <returns>true or false</returns>
        bool ValidButtonPassedIn()
        {
            //  Was an actual button passed in?
            if (currentButton == null)
            {
                ViewDisplay.DisplayViewWarningMessage("CommaBoard button not found in database.");

                return false;
            }

            //  Is a number being entered without a green command button pressed first
            if (currentButton.Buffer && currentButton.RequiresNumber == false && greenCommandButtonPressed == false)
            {
                ViewDisplay.DisplayViewWarningMessage("A number must be prefixed by a green command button.");

                return false;
            }

            //  Is the number string at max length?
            if (currentButton.Buffer && currentButton.RequiresNumber == false && Display.Numbers.NumberBuffer.Length == 7)
            {
                ViewDisplay.DisplayViewWarningMessage("Maximum 7 digits allowed.");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Check the Cathexis client is connected
        /// </summary>
        /// <returns>true or false</returns>
        bool CBClientConnected()
        {
            //  Is the Divitel client connected?
            if (!cbClient.IsConnected())
            {
                //  No point sending if Client isn't connected
                ViewDisplay.DisplayViewWarningMessage("Client not connected to the Server. Please re-connect.");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Is this a button with any special actions
        /// </summary>
        void HandleAnySpecialButtonRequirements()
        {
            //  Is it the Clear button?  If so clear the buffer
            if (currentButton.Name == "Clear")
            {
                ClearBufferedButtonList();

                return;
            }

            //  Is this a Green Command Button?  If so display on screen
            if (currentButton.RequiresNumber)
            {
                //  Set the command button flag
                greenCommandButtonPressed = true;

                //  Clear everything first
                ClearBufferedButtonList();

                //  Now display the name of the button being pressed
                Display.Numbers.ButtonPressedText = currentButton.Value.ToUpper();

                return;
            }

        }

        /// <summary>
        /// Add this button to the buffered string that will display on the Control View
        /// ( but only if it is a button that we need to send bytes for )
        /// </summary>
        void AddButtonNameToButtonsPressedString()
        {
            //  Add the button description to the string
            //  But only if button sends data - and NOT Enter
            if (currentButton.Name != "Enter")
                Display.ButtonsPressedString += $"{ currentButton.Value} ";
        }

        /// <summary>
        /// Add the button to the buffered button list ready for sending
        /// </summary>
        void AddButtonToBufferList()
        {
            //  If this is a Command button set as Command Button object
            if (currentButton.RequiresNumber)
            {
                CommaBoardButton.GreenCommandButton = currentButton;

                return;
            }

            //  Add everything else to the buffer list
            CommaBoardButton.BufferButtonList.Add(currentButton);
        }

        /// <summary>
        /// Clear the buffered button list after data sent
        /// </summary>
        void ClearBufferedButtonList()
        {
            Display.ClearBuffer();

            Display.ClearLabelHighlight();

            CommaBoardButton.ClearCommaBoardButtonList();

            Display.ButtonsPressedString = "";

            Display.Numbers.ButtonPressedText = "";

        }

        /// <summary>
        /// Build the NUMBER value on the Number Display control
        /// </summary>
        void AddDigitToNumberDisplay()
        {
            //  If this is a number add to number display
            if (currentButton.Buffer && !currentButton.RequiresNumber)
            {
                Display.Numbers.NumberBuffer += currentButton.Value;

                Display.Numbers.NumberDisplayNumber = Int32.Parse(Display.Numbers.NumberBuffer);
            }
        }

        #endregion

    }
}
