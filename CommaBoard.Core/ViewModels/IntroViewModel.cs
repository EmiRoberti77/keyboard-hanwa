using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using System.Windows.Media;
using CommaBoard.Store.Library;
using CommaBoard.Store.Static;
using CommaBoard.License;
using System.Windows.Controls;
using Cryptlex;
using CommaBoard.Store.Interface;
using MvvmCross;
using System;
using CommaBoard.Store.Class;
using Newtonsoft.Json;
using CommaBoard.License.Static;
using System.Text.RegularExpressions;
using CommaBoard.Store.Enum;
using System.Collections.Generic;
using System.Reflection;

namespace CommaBoard.Core.ViewModels
{
    public class IntroViewModel : MvxViewModel
    {

        #region     Private Properties

        private readonly IMvxNavigationService _navigationService;

        ICBClient cbClient = Mvx.IoCProvider.Resolve<ICBClient>();

        CBL cbl = new CBL();

        bool progressOK = false;


        #endregion

        #region     Public Properties

        public SettingsViewModel IVMSettingsViewModel { get; set; }
        public ControlViewModel IVMControlViewModel { get; set; }
        public HelpViewModel IVMHelpViewModel { get; set; }

        #endregion

        #region     Other Bindings

        string _introViewTitle;
        public string IntroViewTitle
        {
            get => _introViewTitle;
            set => SetProperty(ref _introViewTitle, value);
        }

        private string _buttonTextControl;
        public string ButtonTextControl
        {
            get => _buttonTextControl;
            set => SetProperty(ref _buttonTextControl, value);
        }

        private string _buttonTextGrids;
        public string ButtonTextGrids
        {
            get => _buttonTextGrids;
            set => SetProperty(ref _buttonTextGrids, value);
        }

        private string _buttonTextSettings;
        public string ButtonTextSettings
        {
            get => _buttonTextSettings;
            set => SetProperty(ref _buttonTextSettings, value);
        }

        private string _buttonTextHelp;
        public string ButtonTextHelp
        {
            get => _buttonTextHelp;
            set => SetProperty(ref _buttonTextHelp, value);
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

        string _username;
        public string Username
        {
            get { return _username; }

            set { 
                
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

        string _licenseKey;
        public string LicenseKey
        {
            get { return _licenseKey; }

            set { SetProperty(ref _licenseKey, value); }
        }

        private bool _showLicenseKey;
        public bool ShowLicenseKey
        {
            get { return _showLicenseKey; }

            set { SetProperty(ref _showLicenseKey, value); }
        }

        private bool _showUserLogin;
        public bool ShowUserLogin
        {
            get { return _showUserLogin; }

            set { SetProperty(ref _showUserLogin, value); }
        }

        private bool _showIntroButtons;
        public bool ShowIntroButtons
        {
            get { return _showIntroButtons; }

            set { SetProperty(ref _showIntroButtons, value); }
        }

        private bool _showPasswordReset;
        public bool ShowPasswordReset
        {
            get { return _showPasswordReset; }

            set { SetProperty(ref _showPasswordReset, value); }
        }

        #endregion

        #region     Constructor

        /// <summary>
        /// Implement the MvvmCross Navigation Service and incorporate DataAccess and CBClient
        /// </summary>
        /// <param name="navigationService">MvvmCross Navigation Service</param>
        /// <param name="dataAccess">Database access</param>
        /// <param name="cbClient">Access to Comms Client</param>
        public IntroViewModel(IMvxNavigationService navigationService )
        {
            _navigationService = navigationService;

            Initialise();
        }

        #endregion

        #region     Commands

        public MvxCommand<object> LoginCommand { get; set; }

        public MvxCommand ActivateLicenseCommand { get; set; }

        public MvxCommand ForgottenPasswordCommand { get; set; }

        public MvxCommand CancelPWResetCommand { get; set; }

        public MvxCommand ConfirmPWResetCommand { get; set; }

        #endregion

        #region     Navigation Buttons

        private IMvxCommand _controlButtonCommand;
        public IMvxCommand ControlButtonCommand
        {
            get
            {
                _controlButtonCommand = _controlButtonCommand ?? new MvxCommand(() => _navigationService.Navigate(IVMControlViewModel));
                return _controlButtonCommand;
            }
        }

        private IMvxCommand _loginButtonCommand;
        public IMvxCommand LoginButtonCommand
        {
            get
            {
                _loginButtonCommand = _loginButtonCommand ?? new MvxCommand(() => _navigationService.Navigate(IVMSettingsViewModel));
                return _loginButtonCommand;
            }
        }

        private IMvxCommand _helpButtonCommand;
        public IMvxCommand HelpButtonCommand
        {
            get
            {
                _helpButtonCommand = _helpButtonCommand ?? new MvxCommand(() => _navigationService.Navigate(IVMHelpViewModel));
                return _helpButtonCommand;
            }
        }

        #endregion

        #region     Public Methods

        /// <summary>
        /// Hide all Intro View controls other than the Login form
        /// </summary>
        public void InitialiseIntroViewDisplay()
        {
            ShowLoginControl();
        }

        #endregion

        #region     Private Initialise Methods

        /// <summary>
        /// IntroViewModel Initialisation methods
        /// </summary>
        void Initialise()
        {
            try
            {
                //  Log start of initialisation
                Log.InfoMessage(LogTextLibrary.INTROVIEWMODEL_INITIALISATION_BEGIN);

                //  Commands
                InitialiseCommands();
                //  Initialisation methods
                InitialiseButtonText();
                InitialiseViewModels();
                InitialiseDisplayContent();

                //  Show the Login Control as the opening User Control on the Intro View
                InitialiseIntroViewDisplay();

                //  Load the User Access Token from Azure API
                //  as we may need it for a password reset
                InitialiseUserAccessToken();

                //  Log end of initialisation
                Log.InfoMessage(LogTextLibrary.INTROVIEWMODEL_INITIALISATION_END);

                //  Start Up Procedures Complete
                Log.InfoMessage(LogTextLibrary.INTROVIEWMODEL_END_COMMABOARD_STARTUP);
            }
            catch(Exception ex)
            {
                //  Log the exception error
                Log.ErrorMessage(ex, LogTextLibrary.INTROVIEWMODEL_INITIALISATION_ERROR, MethodBase.GetCurrentMethod().Name);
            }
            
        }

        /// <summary>
        /// Link the Mvx Commands to methods
        /// </summary>
        void InitialiseCommands()
        {
            LoginCommand = new MvxCommand<object>(LoginButtonPressed);
            ActivateLicenseCommand = new MvxCommand(ActivateLicenseButtonPressed);
            ForgottenPasswordCommand = new MvxCommand(ShowPasswordResetControl);
            ConfirmPWResetCommand = new MvxCommand(ConfirmResetButtonPressed);
            CancelPWResetCommand = new MvxCommand(CancelResetButtonPressed);
        }

        /// <summary>
        /// Add text to each of the Intro View buttons
        /// </summary>
        void InitialiseButtonText()
        {
            ButtonTextControl = DisplayTextLibrary.INTRO_BUTTON_CONTROL_TEXT;
            ButtonTextSettings = DisplayTextLibrary.INTRO_BUTTON_SETTINGS_TEXT;
            ButtonTextHelp = DisplayTextLibrary.INTRO_BUTTON_HELP_TEXT;

        }

        /// <summary>
        /// Initialise all the other ViewModels
        /// </summary>
        void InitialiseViewModels()
        {
            IVMSettingsViewModel = new SettingsViewModel(_navigationService, this);
            IVMControlViewModel = new ControlViewModel(_navigationService, this);
            IVMHelpViewModel = new HelpViewModel(_navigationService, this);
        }

        /// <summary>
        /// Update text on the two message boxes
        /// </summary>
        void InitialiseDisplayContent()
        {
            //  Label that appears above Intro View buttons
            IntroViewTitle = DisplayTextLibrary.INTRO_VIEW_TITLE;

            //  Start up message in View Message Control
            ViewDisplay.DisplayViewInfoMessage(DisplayTextLibrary.INITIAL_VIEW_DISPLAY_MESSAGE);
        }

        /// <summary>
        /// Using the Azure API obtain a User Access Token
        /// </summary>
        async void InitialiseUserAccessToken()
        {
            //  Try obtaining a user access token
            await cbl.LoadAllUsersTokenFromAzureAPI();
        }

        #endregion

        #region     Private Methods

        /// <summary>
        /// A User has logged in so validate them and display 
        /// any return messages
        /// </summary>
        /// <param name="o">PasswordBox o</param>
        async void LoginButtonPressed(object o)
        {
            PasswordBox p = (PasswordBox)o;

            //  Check for valid email and password formats
            if (!LoginDataFormatsValid(false, p.Password)) return;

            await cbl.AuthenticateUser(Username, p.Password);
            if (ErrorInAPICallResponse(cbl.AuthenticateUserResponse)) return;

            //  Get the full User Profile
            await cbl.LoadCurrentUserProfile();
            if (ErrorInAPICallResponse(cbl.GetCurrentUserProfileResponse)) return;

            //  Try loading all Users
            await cbl.LoadUsers(CBLicense.LexLicense.CurrentUserLoggedIn.company);
            if (ErrorInAPICallResponse(cbl.GetAllUsersResponse)) return;

            //  The next viewed control depends on whether the software has been licensed
            if (!cbl.CommaBoardLicenseIsAcivated())
            {
                ShowLicenseKeyControl();

                return;
            }

            //  Update any bindings based on CBL User
            UpdateCBLUserBindings();

            //  Clear the form data
            ClearLoginFormData();

            //  Software is licensed so allow full use of Software
            ShowIntroViewButtonsControl();

            //  Display and Log User successfully logged in
            Utilities.LogAndDisplayInfo($"{CBLicense.LexLicense.CurrentUserLoggedIn.email} logged in");
        }

        /// <summary>
        /// Verify that the email entered is in the correct format
        /// and that the password entered has a valid number of characters
        /// </summary>
        /// <param name="password">the password from the PasswordBox</param>
        /// <returns></returns>
        bool LoginDataFormatsValid(bool ignorePassword,string password)
        {

            if (!EmailValid)
            {
                //	Display and log warning message
                Utilities.LogAndDisplayWarning(GeneralTextLibrary.INVALID_EMAIL_RESPONSE);
                return false;
            }

            if (!ignorePassword && password.Length < 8)
            {
                //	Display and log warning message
                Utilities.LogAndDisplayWarning(GeneralTextLibrary.INVALID_PASSWORD_RESPONSE);
                return false;
            }

            return true;
        }

        /// <summary>
        /// A license key has been entered
        /// </summary>
        void ActivateLicenseButtonPressed()
        {
            string response = cbl.ActivateTheLicenseKey(LicenseKey);

            if (response.IndexOf("Error") != -1)
            {
                //  Something has gone wrong with activating the License Key
                Utilities.LogAndDisplayWarning("An error has occurred in applying the License Key. Please try again.");
                return;
            }

            //  License Key activation successful
            ShowIntroViewButtonsControl();

            //  Log and display successful license key application
            Utilities.LogAndDisplayInfo("License key successfully applied");
        }

        /// <summary>
        /// Cancel password reset and return to Login Control
        /// </summary>
        void CancelResetButtonPressed()
        {
            ShowLoginControl();
        }

        /// <summary>
        /// User wishes to reset their password
        /// </summary>
        async void ConfirmResetButtonPressed()
        {
            //  Do we have a valid email address?
            if (!LoginDataFormatsValid(true, "")) return;

            //  We will need the User's Id so find the User from their email
            await cbl.LoadUserByEmail(Username);
            if(ErrorInAPICallResponse(cbl.GetUserByEmailResponse)) return;

            //  We need a Password Reset Token from the Cryptlex API
            await cbl.ReturnPasswordResetToken(CBLicense.LexLicense.CurrentUserLoggedIn.id);
            if (ErrorInAPICallResponse(cbl.GetPasswordResetTokenResponse)) return;

            //  Send a password reset command
            await cbl.ResetPasswordForUser(CBLicense.LexLicense.CurrentUserLoggedIn.id);
            if (ErrorInAPICallResponse(cbl.GetPasswordResetResponse)) return;

            //  Whatever the response, show the login control again
            ShowLoginControl();

            //  Log password reset
            Log.InfoMessage($"{CBLicense.LexLicense.CurrentUserLoggedIn.email} requested password reset");
        }

        /// <summary>
        /// All checks complete so show the intro buttons
        /// </summary>
        void ShowIntroViewButtonsControl()
        {
            //  Show Intro Buttons
            ShowIntroButtons = true;
            ShowLicenseKey = false;
            ShowUserLogin = false;
            ShowPasswordReset = false;
        }

        /// <summary>
        /// CommaBoard not yet licensed so show the License Key control
        /// </summary>
        void ShowLicenseKeyControl()
        {
            ShowIntroButtons = false;
            ShowLicenseKey = true;
            ShowUserLogin = false;
            ShowPasswordReset = false;
        }

        /// <summary>
        /// The first thing a User sees is the Login Control
        /// </summary>
        void ShowLoginControl()
        {
            ShowIntroButtons = false;
            ShowLicenseKey = false;
            ShowUserLogin = true;
            ShowPasswordReset = false;
        }

        /// <summary>
        /// If the User requests a password reset then display 
        /// the Password Reset Control
        /// </summary>
        void ShowPasswordResetControl()
        {
            ShowIntroButtons = false;
            ShowLicenseKey = false;
            ShowUserLogin = false;
            ShowPasswordReset = true;
        }

        /// <summary>
        /// Blank out the Login form fields
        /// </summary>
        void ClearLoginFormData()
        {
            Username = "";
        }

        /// <summary>
        /// Now we have a logged in User display any
        /// User bindings to Control View or Settings View
        /// </summary>
        void UpdateCBLUserBindings()
        {
            //  Set up User data for Control View and Settings
            UserDisplay.DisplayUserLoggedIn();
        }

        #endregion

        #region     Private Utility Methods

        bool ErrorInAPICallResponse(string response)
        {
            if (response.IndexOf("Error") != -1)
            {
                //	Log and display problem message
                Utilities.LogAndDisplayWarning(response);
                return true;
            }

            //	Log and display success message
            Utilities.LogAndDisplayInfo(response);
            return false;
        }

        #endregion

    }
}
