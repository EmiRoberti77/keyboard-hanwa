using System.Collections.Generic;
using CommaBoard.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Windows.Media;
using System.Linq;
using MvvmCross;
using CommaBoard.Store.Class;
using CommaBoard.Store.Interface;
using CommaBoard.Store.Library;
using CommaBoard.Store.Static;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Threading;
using CommaBoard.License.Static;
using CommaBoard.Store.Enum;
using System.Reflection;

namespace CommaBoard.Core.ViewModels
{
    public class ControlViewModel : MvxViewModel
    {

        #region     Private Fields

        private readonly IMvxNavigationService _navigationService;

        CommaBoardButton currentButton;

        IntroViewModel introViewModel;

        IDataAccess dataAccess = Mvx.IoCProvider.Resolve<IDataAccess>();

        ICommaBoardButtonModel buttonModel = Mvx.IoCProvider.Resolve<ICommaBoardButtonModel>();

        ICBClient cbClient = Mvx.IoCProvider.Resolve<ICBClient>();

        private readonly TaskFactory _dispatcher;

        #endregion

        #region     Text And Misc Bindings

        string _viewTitle;
        public string ViewTitle
        {
            get { return _viewTitle; }

            set { SetProperty(ref _viewTitle, value); }
        }

        string _informationText;
        public string InformationText
        {
            get { return _informationText; }

            set { SetProperty(ref _informationText, value); }
        }

        string _messageControlTitle;
        public string MessageControlTitle
        {
            get { return _messageControlTitle; }

            set { SetProperty(ref _messageControlTitle, value); }
        }

        Brush _messageControlForeground;
        public Brush MessageControlForeground
        {
            get { return _messageControlForeground; }

            set { SetProperty(ref _messageControlForeground, value); }
        }

        string _messageControlText;
        public string MessageControlText
        {
            get { return _messageControlText; }

            set { SetProperty(ref _messageControlText, value); }
        }

        string _betaMessageText;
        public string BetaMessageText
        {
            get { return _betaMessageText; }

            set { SetProperty(ref _betaMessageText, value); }
        }      

        #endregion

        #region     Led Light Binding

        BitmapImage _transmit;
        public BitmapImage Transmit
        {
            get { return _transmit; }

            set { SetProperty(ref _transmit, value); }
        }

        BitmapImage _receive;
        public BitmapImage Receive
        {
            get { return _receive; }

            set { SetProperty(ref _receive, value); }
        }

        public Uri UriRed = new Uri("pack://application:,,,/Resources/Images/ledRed.jpg");

        public Uri UriGreen = new Uri("pack://application:,,,/Resources/Images/ledGreen.jpg");

        #endregion

        #region     Commands

        private IMvxCommand _goBackCommand;
        public IMvxCommand GoBackCommand
        {
            get
            {
                _goBackCommand = _goBackCommand ?? new MvxCommand(() => _navigationService.Navigate(introViewModel));
                return _goBackCommand;
            }
        }

        public MvxCommand<string> CommaBoardButtonCommand { get; set; }

        public MvxCommand ChangeLayoutPanelCommand { get; set; }

        public MvxCommand CancelCreateCommand { get; set; }

        public MvxCommand LayoutViewCommand { get; set; }

        public MvxCommand ToggleVideowallButtonCommand { get; set; }

        public MvxCommand StartRecordingCommand { get; set; }

        public MvxCommand StopRecordingCommand { get; set; }

        public MvxCommand PreviousLayoutCommand { get; set; }

        public MvxCommand NextLayoutCommand { get; set; }

        public MvxCommand RefreshLayoutsCommand { get; set; }

        public MvxCommand RefreshCamerasCommand { get; set; }

        public MvxCommand ShowResourcesCommand { get; set; }

        public MvxCommand ShowPlaybackCommand { get; set; }

        public MvxCommand LogOutCommand { get; set; }

        public MvxCommand ConfirmLogOutCommand { get; set; }

        public MvxCommand CancelLogOutCommand { get; set; }

        #endregion

        #region     Constructor

        public ControlViewModel(IMvxNavigationService navigationService, IntroViewModel ivm)
        {
            _navigationService = navigationService;
            buttonModel = new WaveCommaBoardButtonModel();

            _dispatcher = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

            introViewModel = ivm;

            Initialise();

        }

        public ControlViewModel()
        {
        }

        #endregion

        #region     Private Initialise Methods

        /// <summary>
        /// All the ControlViewModel methods at start up
        /// </summary>
        private void Initialise()
        {
            try
            {
                //  Log start of initialisation
                Log.InfoMessage(LogTextLibrary.CONTROLVIEWMODEL_INITIALISATION_BEGIN);

                //  Initialisation methods
                InitialiseCommands();
                InitialiseVariousControlText();
                InitialiseDisplayNumbers();
                InitialiseCommaBoardButtons();
                InitialiseCommaBoardButtonList();
                InitialiseNumberDisplay();
                InitialiseLedLights();
                InitialiseWaveGrid();
                InitialiseVisibilityOptions();
                InitialiseUsers();

                //  Log end of ControlViewModel initialisation
                Log.InfoMessage(LogTextLibrary.CONTROLVIEWMODEL_INITIALISATION_END);

            }
            catch(Exception ex)
            {
                //  Log the error
                Log.ErrorMessage(ex, LogTextLibrary.CONTROLVIEWMODEL_INITIALISATION_ERROR, MethodBase.GetCurrentMethod().Name);
            }
            
        }

        /// <summary>
        /// Brings back a list of Licensed Users at this location
        /// </summary>
        void InitialiseUsers()
        {
            //  Do this via a faux button click
            CommaBoardButtonPressed("RefreshUsers");
        }

        /// <summary>
        /// Link the public MvxCommands to private methods
        /// </summary>
        void InitialiseCommands()
        {
            //  Generic CommaBoard Key Press method
            Action<string> CommaBoardButtonAction = new Action<string>(CommaBoardButtonPressed);
            CommaBoardButtonCommand = new MvxCommand<string>(CommaBoardButtonAction);
            LayoutViewCommand = new MvxCommand(LayoutViewButtonPressed);
            ChangeLayoutPanelCommand = new MvxCommand(ChangeLayoutButtonPressed);
            CancelCreateCommand = new MvxCommand(CancelCreateButtonPressed);
            ToggleVideowallButtonCommand = new MvxCommand(ToggleVideowallButtonPressed);
            StartRecordingCommand = new MvxCommand(StartRecordingButtonPressed);
            StopRecordingCommand = new MvxCommand(StopRecordingButtonPressed);
            PreviousLayoutCommand = new MvxCommand(PreviousLayoutButtonPressed);
            NextLayoutCommand = new MvxCommand(NextLayoutButtonPressed);
            RefreshCamerasCommand = new MvxCommand(LoadWaveCameras);
            RefreshLayoutsCommand = new MvxCommand(LoadWaveLayouts);
            ShowResourcesCommand = new MvxCommand(ShowResourcesButtonPressed);
            ShowPlaybackCommand = new MvxCommand(ShowPlaybackButtonPressed);
            LogOutCommand = new MvxCommand(LogOutButtonPressed);
            ConfirmLogOutCommand = new MvxCommand(ConfirmLogOutButtonPressed);
            CancelLogOutCommand = new MvxCommand(CancelLogOutButtonPressed);
        }

        /// <summary>
        /// Display text for the Control View
        /// </summary>
        void InitialiseVariousControlText()
        {
            ViewTitle = DisplayTextLibrary.CONTROL_VIEW_TITLE;
            InformationText = DisplayTextLibrary.CONTROL_VIEW_INFO_TEXT;

            //  The Number Display Figures
            Display.Numbers.NumberBuffer = "";

            //  Shortcut target
            Display.Numbers.NumberShortcutTarget = 0;
            Display.SetShortcutTarget();
        }

        /// <summary>
        /// Initialise the number display control
        /// </summary>
        void InitialiseDisplayNumbers()
        {
            Display.Numbers.NumberDisplayNumber = 0;
            Display.Numbers.NumberDisplayMonitor = 1;
            Display.Numbers.NumberDisplayCamera = 0;
            Display.Numbers.NumberDisplayLayout = 1;

            //  Start the timer to display the date and time on the title control
            Display.StartDisplayTimer();

        }

        /// <summary>
        /// Load all the CommaBoard Buttons from the database
        /// </summary>
        void InitialiseCommaBoardButtons()
        {
            CommaBoardButton.DBCommaBoardButtonList = new List<CommaBoardButton>();
            CommaBoardButton.DBCommaBoardButtonList.AddRange(dataAccess.LoadCommaBoardButtons(QueryStringLibrary.QS_LoadCommaBoardButtons()));
        }

        /// <summary>
        /// Start with an empty button list for data sending
        /// </summary>
        void InitialiseCommaBoardButtonList()
        {
            Display.ClearLabelHighlight();

            CommaBoardButton.ClearCommaBoardButtonList();
        }

        /// <summary>
        /// Set the RX and TX lights to red
        /// </summary>
        void InitialiseLedLights()
        {
            Receive = new BitmapImage(UriRed);
            Transmit = new BitmapImage(UriRed);
        }

        /// <summary>
        /// Clear the Number Display control with no command highlighted
        /// </summary>
        void InitialiseNumberDisplay()
        {
            Display.ClearLabelHighlight();
        }

        /// <summary>
        /// Load the Wave client cameras and layouts
        /// </summary>
        void InitialiseWaveGrid()
        {
            //  Initialise current logical Id numbers
            Wave.Grid.CurrentLayoutLogicalId = 1;
            Wave.Grid.CurrentCameraLogicalId = 0;

            //  Load all Wave Cameras
            LoadWaveCameras();

            //  Load all Wave Layouts
            LoadWaveLayouts();

        }

        /// <summary>
        /// Set the visibility of certain user controls
        /// </summary>
        void InitialiseVisibilityOptions()
        {
            ControlVisible.UCVisible.StartRecordingEnabled = true;
            ControlVisible.UCVisible.StopRecordingEnabled = false;
            ControlVisible.UCVisible.LayoutMoveEnabled = true;

            ShowResourcesButtonPressed();


        }

        #endregion

        #region     Private Button Command Methods

        /// <summary>
        /// A CommaBoard button has been pressed
        /// Check it is a valid database button then pass to the CommaBoard Button Model for handling
        /// </summary>
        /// <param name="key"></param>
        void CommaBoardButtonPressed(string key)
        {
            //  Which CommaBoard button is this?
            currentButton = CommaBoardButton.DBCommaBoardButtonList.Where(c => c.Name == key).FirstOrDefault();

            //  Pass the button to the CommaBoard Button Model for processing
            buttonModel.HandleButtonPress(currentButton);

            if(buttonModel.DataSent)
            {
                buttonModel.DataSent = false;
            }

        }

        void ChangeLayoutButtonPressed()
        {
            ControlVisible.UCVisible.LayoutCreated = false;
            ControlVisible.UCVisible.LayoutNotCreated = true;
        }

        void CancelCreateButtonPressed()
        {
            ControlVisible.UCVisible.LayoutCreated = true;
            ControlVisible.UCVisible.LayoutNotCreated = false;
        }

        void LayoutViewButtonPressed()
        {
            ControlVisible.UCVisible.LiveViewEnabled = false;
            ControlVisible.UCVisible.LayoutViewEnabled = true;
            ControlVisible.UCVisible.LayoutCreated = true;
            ControlVisible.UCVisible.LayoutNotCreated = false;
        }

        void StartRecordingButtonPressed()
        {
            //  Swap recording buttons
            ControlVisible.UCVisible.StartRecordingEnabled = false;
            ControlVisible.UCVisible.StopRecordingEnabled = true;

            //  Send a faux CommaBoard button command to start recording
            CommaBoardButtonPressed("sc_StartRecording");
        }

        void StopRecordingButtonPressed()
        {
            //  Swap recording buttons
            ControlVisible.UCVisible.StartRecordingEnabled = true;
            ControlVisible.UCVisible.StopRecordingEnabled = false;

            //  Send a faux CommaBoard button command to stop recording
            CommaBoardButtonPressed("sc_StopRecording");
        }

        void PreviousLayoutButtonPressed()
        {
            //  Send a faux CommaBoard button command to start recording
            CommaBoardButtonPressed("sc_PrevLayout");

            //  Now change the Selected Layout
            Wave.Grid.CurrentLayoutLogicalId = Wave.ChangeSelectedLayoutLogicalId(true);

            Wave.Grid.UpdateSelectedLayout();
        }

        void NextLayoutButtonPressed()
        {
            //  Send a faux CommaBoard button command to start recording
            CommaBoardButtonPressed("sc_NextLayout");

            //  Now change the Selected Layout
            Wave.Grid.CurrentLayoutLogicalId = Wave.ChangeSelectedLayoutLogicalId(false);

            Wave.Grid.UpdateSelectedLayout();
        }

        /// <summary>
        /// Toggle between the Wave Client and Videowall 
        /// as the target application for shortcut keys
        /// </summary>
        void ToggleVideowallButtonPressed()
        {
            int temp = Display.Numbers.NumberShortcutTarget;

            if (temp == 0)
            {
                Display.Numbers.NumberShortcutTarget = 1;

                ControlVisible.UCVisible.LayoutMoveEnabled = false;
            }

            if (temp == 1)
            {
                Display.Numbers.NumberShortcutTarget = 0;

                ControlVisible.UCVisible.LayoutMoveEnabled = true;
            }

            Display.SetShortcutTarget();
            
        }

        /// <summary>
        /// Show the resources control and hide the playback control
        /// </summary>
        void ShowResourcesButtonPressed()
        {
            ControlVisible.UCVisible.ResourcesVisible = true;
            ControlVisible.UCVisible.PlaybackVisible = false;

            //  Effectively Live Mode so send the switch to Live shortcut command
            CommaBoardButtonPressed("sc_Live");
        }

        /// <summary>
        /// Show the playback control and hide the resources control
        /// </summary>
        void ShowPlaybackButtonPressed()
        {
            ControlVisible.UCVisible.ResourcesVisible = false;
            ControlVisible.UCVisible.PlaybackVisible = true;

            CommaBoardButtonPressed("sc_Playback");
        }

        void LogOutButtonPressed()
        {
            UserDisplay.ConfirmOrCancelUserLogout();
        }

        void ConfirmLogOutButtonPressed()
        {
            //  Show the Login Control on the Intro View
            introViewModel.InitialiseIntroViewDisplay();

            //  Navigate to the Intro View
            _navigationService.Navigate(introViewModel);
        }

        void CancelLogOutButtonPressed()
        {
            UserDisplay.DisplayUserLoggedIn();
        }

        #endregion

        #region     Private HTTPClient Loading Methods

        /// <summary>
        /// Use the Wave API to load all available cameras
        /// </summary>
        void LoadWaveCameras()
        {
            try
            {
                //  Do this via a faux button click
                CommaBoardButtonPressed("RefreshCameras");
            }
            catch(Exception ex)
            {
                //  Log the error
                

                
            }
            
        }

        /// <summary>
        /// Load the Wave API to load all the available Layouts
        /// </summary>
        void LoadWaveLayouts()
        {
            try
            {
                //  Do this via a faux button click
                CommaBoardButtonPressed("RefreshLayouts");


            }
            catch(Exception ex)
            {
                //  Log the error
               
            }
            
        }

        #endregion

    }
}
