using System;
using MvvmCross.ViewModels;
using System.Linq;
using MvvmCross.Commands;
using MvvmCross;
using MvvmCross.Navigation;
using System.Windows.Media;
using System.Collections.Generic;
using CommaBoard.Store.Class;
using CommaBoard.Store.Interface;
using CommaBoard.Store.Library;
using CommaBoard.Store.Enum;
using CommaBoard.Store.Static;
using CommaBoard.License.Helper;
using SharpDX.DirectInput;
using CommaBoard.License.Class;
using CommaBoard.License.Static;
using CommaBoard.License;
using System.Text.RegularExpressions;
using System.Reflection;

namespace CommaBoard.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        #region     Private Fields

        readonly IMvxNavigationService _navigationService;

        IntroViewModel introViewModel;

        IDataAccess dataAccess = Mvx.IoCProvider.Resolve<IDataAccess>();

        ICBClient cbClient = Mvx.IoCProvider.Resolve<ICBClient>();

        IDataSentModel dataSentModel = Mvx.IoCProvider.Resolve<IDataSentModel>();

        //  JoystickModel joystickModel;

        List<SettingsParameter> paramList;

        List<SettingsParameter> soundParams;

        CBL cbl = new CBL();


        #endregion

        #region     Settings Parameter Bindings

        SettingsParameter _waveIP;
        public SettingsParameter WaveIP
        {
            get { return _waveIP; }

            set { SetProperty(ref _waveIP, value); }
        }

        SettingsParameter _wavePort;
        public SettingsParameter WavePort
        {
            get { return _wavePort; }

            set { SetProperty(ref _wavePort, value); }
        }

        SettingsParameter _waveUsername;
        public SettingsParameter WaveUsername
        {
            get { return _waveUsername; }

            set { SetProperty(ref _waveUsername, value); }
        }

        SettingsParameter _wavePassword;
        public SettingsParameter WavePassword
        {
            get { return _wavePassword; }

            set { SetProperty(ref _wavePassword, value); }
        }

        #endregion

        #region     Text And Misc Bindings

        string _settingsMessage;
        public string SettingsMessage
        {
            get { return _settingsMessage; }
            
            set { SetProperty(ref _settingsMessage, value); }
        }

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

        string _textBoxText;
        public string TextBoxText
        {
            get { return _textBoxText; }

            set { SetProperty(ref _textBoxText, value); }
        }

        List<string> _availableParam2s;
        public List<string> AvailableParam2s
        {
            get { return _availableParam2s; }

            set { SetProperty(ref _availableParam2s, value); }
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

        bool _joystickRequired;
        public bool JoystickRequired
        {
            get { return _joystickRequired; }

            set
            {
                SetProperty(ref _joystickRequired, value);
            }
        }

        string _joystickName;
        public string JoystickName
        {
            get { return _joystickName; }

            set { SetProperty(ref _joystickName, value); }
        }

        string _nuFirstName;
        public string NUFirstName
        {
            get { return _nuFirstName; }

            set { SetProperty(ref _nuFirstName, value); }
        }

        string _nuLastName;
        public string NULastName
        {
            get { return _nuLastName; }

            set { SetProperty(ref _nuLastName, value); }
        }

        string _nuEmail;
        public string NUEmail
        {
            get { return _nuEmail; }

            set { SetProperty(ref _nuEmail, value); }
        }

        string _nuStatus;
        public string NUStatus
        {
            get { return _nuStatus; }

            set { SetProperty(ref _nuStatus, value); }
        }

        #endregion

        #region     Bindings  -  ComboBox Lists

        IList<DeviceInstance> _connectedHIDDevices;
        public IList<DeviceInstance> ConnectedHIDDevices
        {
            get { return _connectedHIDDevices; }

            set { SetProperty(ref _connectedHIDDevices, value); }
        }

        string _firstName;
        public string FirstName
        {
            get { return _firstName; }

            set { SetProperty(ref _firstName, value); ; }
        }

        string _lastName;
        public string LastName
        {
            get { return _lastName; }

            set { SetProperty(ref _lastName, value); ; }
        }

        MvxObservableCollection<string> _roleItems;
        public MvxObservableCollection<string> RoleItems
        {
            get { return _roleItems; }

            set { SetProperty(ref _roleItems, value); }
        }

        string _selectedRole;
        public string SelectedRole
        {
            get { return _selectedRole; }

            set { SetProperty(ref _selectedRole, value); }
        }

        string _username;
        public string Username
        {
            get { return _username; }

            set
            {

                SetProperty(ref _username, value);

                if (!Regex.IsMatch(value, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    EmailForeground = Brushes.Red;
                    EmailValid = false;
                    return;
                }

                EmailForeground = Brushes.Black;
                EmailValid = true;

            }
        }

        Brush _emailForeground;
        public Brush EmailForeground
        {
            get { return _emailForeground; }

            set { SetProperty(ref _emailForeground, value); ; }
        }

        bool _emailValid;
        public bool EmailValid
        {
            get { return _emailValid; }

            set { SetProperty(ref _emailValid, value); }
        }


        #endregion

        #region     Enabling Buttons

        bool _saveSettingsEnabled;
        public bool SaveSettingsEnabled
        {
            get { return _saveSettingsEnabled; }

            set { SetProperty(ref _saveSettingsEnabled, value); }
        }

        bool _openSerialPortEnabled;
        public bool OpenSerialPortEnabled
        {
            get { return _openSerialPortEnabled; }

            set { SetProperty(ref _openSerialPortEnabled, value); }
        }

        #endregion

        #region     Commands

        public MvxCommand SaveSettingsCommand { get; set; }

        private IMvxCommand _goBackCommand;
        public IMvxCommand GoBackCommand
        {
            get
            {
                _goBackCommand = _goBackCommand ?? new MvxCommand(() => _navigationService.Navigate(introViewModel));
                return _goBackCommand;
            }
        }

        public MvxCommand SaveLoginCredentialsCommand { get; set; }

        public MvxCommand LoginAsAdminCommand { get; set; }

        public MvxCommand LockControlsCommand { get; set; }

        public MvxCommand SearchForDevicesCommand { get; set; }

        public MvxCommand SaveDeviceCommand { get; set; }

        public MvxCommand ConfirmNewUser { get; set; }


        #endregion

        #region     Constructors

        public SettingsViewModel(IMvxNavigationService navigationService, IntroViewModel ivm)
        {
            _navigationService = navigationService;
            introViewModel = ivm;

            Initialise();
            
        }

        #endregion

        #region     Private Initialise Methods

        /// <summary>
        /// Initialise the SettingsViewModel
        /// </summary>
        void Initialise()
        {
            try
            {
                //  Log start of initialisation
                Log.InfoMessage(LogTextLibrary.SETTINGSVIEWMODEL_INITIALISATION_BEGIN, MethodBase.GetCurrentMethod().Name);

                //  Initialisation methods
                //  LoadTheJoystickModel();
                InitialiseCommands();
                InitialiseSoundSettings();
                InitialiseButtonsAtStartUp();
                InitialiseComboBoxes();
                InitialiseVariousSettingsText();
                InitialiseAdminUserStatus();
                InitialiseConnectionSettings();
                InitialiseHttpClientSettings();                

                //  Log successful initialisation
                Log.InfoMessage(LogTextLibrary.SETTINGSVIEWMODEL_INITIALISATION_END, MethodBase.GetCurrentMethod().Name);
            }
            catch(Exception ex)
            {
                //  Log the error
                Log.ErrorMessage(ex, LogTextLibrary.SETTINGSVIEWMODEL_INITIALISATION_ERROR, MethodBase.GetCurrentMethod().Name);
            }
            
        }

        /// <summary>
        /// Link the public MxxCommands to private methods
        /// </summary>
        void InitialiseCommands()
        {
            //  SearchForDevicesCommand = new MvxCommand(SearchForDevicesButton);
            //  SaveDeviceCommand = new MvxCommand(SaveDeviceButton);
            SaveSettingsCommand = new MvxCommand(SaveConnectionSettings);
            ConfirmNewUser = new MvxCommand(ConfirmCreateNewUserButtonPressed);
        }

        /// <summary>
        /// Load wav file names from the database
        /// </summary>
        void InitialiseSoundSettings()
        {
            soundParams = dataAccess.LoadSettings(QueryStringLibrary.QS_LoadSettingsParametersByType(SettingsType.Sound.ToString()));
            StorePlayer.WavSoundClientDisconect = soundParams.Where(p => p.Name == "SoundClientDisconnect").First().StringValue;
            StorePlayer.WavSoundJoystickDisconect = soundParams.Where(p => p.Name == "SoundJoystickDisconnect").First().StringValue;
            StorePlayer.WavSoundVolume = soundParams.Where(p => p.Name == "SoundVolume").First().IntValue;
        }

        /// <summary>
        /// Enable/Disable buttons at start up
        /// </summary>
        void InitialiseButtonsAtStartUp()
        {
            OpenSerialPortEnabled = true;
            SaveSettingsEnabled = true;
        }

        /// <summary>
        /// Data for any Settings comboboxes
        /// </summary>
        void InitialiseComboBoxes()
        {
            RoleItems = new MvxObservableCollection<string>() { "user", "admin" };
        }

        /// <summary>
        /// Load any text to be displayed from the Text Library
        /// </summary>
        void InitialiseVariousSettingsText()
        {
            ViewTitle = DisplayTextLibrary.SETTINGS_VIEW_TITLE;
            InformationText = DisplayTextLibrary.SETTINGS_VIEW_INFO_TEXT;
        }

        /// <summary>
        /// Clear the bool that determines whether logged-in User is Admin
        /// </summary>
        void InitialiseAdminUserStatus()
        {
            UserType.Admin.LoggedIn = false;
        }

        /// <summary>
        /// Load saved connection settings from the database
        /// </summary>
        void InitialiseConnectionSettings()
        {
            try
            {
                paramList = dataAccess.LoadSettings(QueryStringLibrary.QS_LoadSettingsParameters());
                WaveIP = paramList.Where(p => p.Name == "WaveIP").First();
                WavePort = paramList.Where(p => p.Name == "WavePort").First();
                WaveUsername = paramList.Where(p => p.Name == "WaveUsername").First();
                WavePassword = paramList.Where(p => p.Name == "WavePassword").First();

                //  Log success
                Log.InfoMessage("Connection Settings loaded", MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                //  Log and display the exception error
  
            }
        }

        /// <summary>
        /// Initialise the Wisenet WAVE HTTP client
        /// </summary>
        void InitialiseHttpClientSettings()
        {
            string fullAddress = $"https://{WaveIP.StringValue}:{WavePort.StringValue}/";
            Uri uri = new Uri(fullAddress);
            ApiHelper.InitializeClient(uri, WaveUsername.StringValue, WavePassword.StringValue);
            
        }

        #endregion

        #region     Private Button Command Methods

        /// <summary>
        /// Save the Wisenet WAVE connection settings to the database
        /// </summary>
        void SaveConnectionSettings()
        {
            try
            {
                //  Save all the connection settings parameters
                dataAccess.UpdateQuery(QueryStringLibrary.QS_UpdateSettingsParameter(WaveIP));
                dataAccess.UpdateQuery(QueryStringLibrary.QS_UpdateSettingsParameter(WavePort));
                dataAccess.UpdateQuery(QueryStringLibrary.QS_UpdateSettingsParameter(WaveUsername));
                dataAccess.UpdateQuery(QueryStringLibrary.QS_UpdateSettingsParameter(WavePassword));

                //	Log and display success message
                Utilities.LogAndDisplayInfo("Server connection settings successfully saved");

            }
            catch(Exception ex)
            {
                //  Log and display the exception error
                Utilities.LogAndDisplayError(ex, "Error trying to save server connection settings");
            }
        }

        /// <summary>
        /// Create a new CommaBoard User to be added to the Cryptlex dashboard
        /// </summary>
        async void ConfirmCreateNewUserButtonPressed()
        {
            //  Check the form fields are valid
            if(!NewUserIsValidated()) return;
            
            CBLUser user = BuildNewUserFromFormData();

            await cbl.CreateNewUser(user);

            if (cbl.CreateNewUserResponse.IndexOf("Error") != -1)
            {
                //	Log and display problem message
                Utilities.LogAndDisplayWarning(cbl.CreateNewUserResponse);
                return;
            }

            //  Log and display successful creation of new User
            Utilities.LogAndDisplayInfo($"New User {Username} created. A welcome email has been sent to their email address");

            //  Once the new User is created the form data needs to be emptied 
            ClearNewUserFormData();
        }

        /// <summary>
        /// Check that the email and password are both valid
        /// </summary>
        /// <returns></returns>
        bool NewUserIsValidated()
        {
            if (!EmailValid)
            {
                //	Display message
                Utilities.LogAndDisplayWarning(GeneralTextLibrary.INVALID_EMAIL_RESPONSE);
                return false;
            }

            if(SelectedRole == null)
            {
                //	Display message
                Utilities.LogAndDisplayWarning(GeneralTextLibrary.INVALID_PASSWORD_RESPONSE);
                return false;

                return false;
            }

            return true;

        }

        /// <summary>
        /// Add the new User form data to any preset data before
        /// submitting to the Cryptlex API
        /// </summary>
        /// <returns></returns>
        CBLUser BuildNewUserFromFormData()
        {
            //  Build up the new User from the form data
            //  and generated data
            CBLUser user = new CBLUser();
            Metadata[] metaarrary = new Metadata[]
            {
                new Metadata(){ key="user_data", value=SelectedRole}
            };

            user.firstName = FirstName;
            user.lastName = LastName;
            user.email = Username;
            user.password = PasswordGenerator.GeneratePassword(true, true, true, true, false, 10);
            user.allowCustomerPortalAccess = true;
            user.company = CBLicense.LexLicense.CurrentUserLoggedIn.company;
            user.role = "user";
            user.metadata = metaarrary;

            return user;
        }

        /// <summary>
        /// Reset the New User form
        /// </summary>
        void ClearNewUserFormData()
        {
            FirstName = "";
            LastName = "";
            Username = "";
        }

        #endregion


    }
}
