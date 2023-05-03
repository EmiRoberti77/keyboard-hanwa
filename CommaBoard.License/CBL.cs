using System.Threading.Tasks;
using CommaBoard.License.Client;
using CommaBoard.License.Class;
using CommaBoard.License.Static;
using CommaBoard.License.Helper;
using Newtonsoft.Json;
using System;
using CommaBoard.Store.Class;
using System.Collections.Generic;
using CommaBoard.Store.Interface;
using MvvmCross;
using CommaBoard.Store.Library;
using System.Linq;

namespace CommaBoard.License
{
    public class CBL
    {

        #region     Private Properties

        CBLClient cblClient = new CBLClient();

        AzureClient azureClient = new AzureClient();

        IDataAccess dataAccess = Mvx.IoCProvider.Resolve<IDataAccess>();

        string authenticateResponse = "";

        #endregion

        #region     Public Properties

        public string AuthenticateUserResponse { get; set; }

        public string GetCurrentUserProfileResponse { get; set; }

        public string GetAllUsersResponse { get; set; }

        public string GetUserByEmailResponse { get; set; }

        public string GetPasswordResetTokenResponse { get; set; }

        public string GetPasswordResetResponse { get; set; }

        public string CreateNewUserResponse { get; set; }

        #endregion

        #region     Constructor

        public CBL()
        {
            Initialise();
        }

        #endregion

        #region     Public Non-API Methods

        /// <summary>
        /// Check if a valid License Key has been applied to this machine
        /// </summary>
        /// <returns>true/false</returns>
        public bool CommaBoardLicenseIsAcivated()
        {
            return CBLicense.LicenseIsActivated;
        }

        /// <summary>
        /// Return any notes associated with the License Key status
        /// </summary>
        /// <returns></returns>
        public string LicenseActivationStatus()
        {
            return CBLicense.LicenseActivationStatus;
        }

        /// <summary>
        /// License this machine for CommaBoard using the passed in License Key
        /// </summary>
        /// <param name="key">License Key</param>
        /// <returns></returns>
        public string ActivateTheLicenseKey(string key)
        {
            CBLicense.LexLicense.CBLLicenseKey = key;

            return CBLicense.ActivateLicenseOnThismachine();
        }

        #endregion

        #region     Public API Call Methods

        /// <summary>
        /// Validate the User's login credentials
        /// </summary>
        /// <returns></returns>
        public async Task AuthenticateUser(string username, string password)
        {
            CBLicense.LexLicense.CBLUsername = username;
            CBLicense.LexLicense.CBLPassword = password;

            cblClient.ApiCommand = "accounts/login";
            cblClient.ApiMessage = SerializeUserData();

            Task<string> taskAuthenticate = cblClient.ValidateUser();
            var temp = await taskAuthenticate;
            
            AuthenticateUserResponse = temp;

        }

        /// <summary>
        /// Having validated the User's credentials, Cryptlex will return the full User profile
        /// </summary>
        public async Task LoadCurrentUserProfile()
        {
            //  Set the URI
            cblClient.ApiCommand = "me";

            //  Run the API request
            Task<string> taskCurrentUser = cblClient.GetCurrentUser();
            var temp = await taskCurrentUser;

            GetCurrentUserProfileResponse = temp;
        }

        /// <summary>
        /// Load ALL Users registered to this PC/node
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task LoadUsers(string company)
        {
            //  Get all the Current User data
            cblClient.ApiCommand = "users?company=" + company;

            Task<string> taskUsers = cblClient.GetUserList();
            var temp = await taskUsers;

            GetAllUsersResponse = temp;

        }

        /// <summary>
        /// Load a User by their email ( for password reset purposes )
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task LoadUserByEmail(string email)
        {
            //  Get all the Current User data
            cblClient.ApiCommand = $"users?email={email}";

            Task<string> taskUsers = cblClient.GetUserList();
            var temp = await taskUsers;

            GetUserByEmailResponse = temp;

            CBLicense.LexLicense.CurrentUserLoggedIn = CBLicense.LexLicense.CommaBoardUsers.FirstOrDefault();

        }

        /// <summary>
        /// In order to reset a User's password you have
        /// to first obtain a password reset token from the Cryptlex API
        /// </summary>
        /// <param name="userid">User's Id</param>
        /// <returns></returns>
        public async Task ReturnPasswordResetToken(string userid)
        {
            //  Add User Id to the request URI
            cblClient.ApiCommand = $"users/{userid}/reset-password-token";

            Task<string> taskUsers = cblClient.GetPasswordResetToken();
            var temp = await taskUsers;

            GetPasswordResetTokenResponse = temp;
        }

        /// <summary>
        /// Send a password reset request to the API
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task ResetPasswordForUser(string userid)
        {
            //  Set the URI and the request body
            cblClient.ApiCommand = $"users/{userid}/reset-password";
            cblClient.ApiMessage = SerializePasswordResetData();

            //  Run the API request
            Task<string> taskResetPassword = cblClient.ResetPassword();
            var temp = await taskResetPassword;

            GetPasswordResetResponse = temp;
        }

        /// <summary>
        /// Create a new User for this location
        /// </summary>
        /// <returns></returns>
        public async Task CreateNewUser(CBLUser user)
        {
            //  Set the URI and the request body
            cblClient.ApiCommand = "users";
            cblClient.ApiMessage = JsonConvert.SerializeObject(user);

            //  Run the API request
            Task<string> taskCreateUser = cblClient.CreateUser();
            var temp = await taskCreateUser;

           CreateNewUserResponse = temp;
        }

        #endregion

        #region     Public Azure API Methods

        /// <summary>
        /// Retrieve an appropriate Cryptlex Access Token
        /// held behind the CommandRooms Azure API
        /// </summary>
        /// <returns></returns>
        public async Task LoadAllUsersTokenFromAzureAPI()
        {
            //  Get all the Current User data
            azureClient.ApiCommand = "?name=AllUsers";
            azureClient.ApiMessage = "";

            Task<string> taskUsers = azureClient.GetAccessToken();
            var temp = await taskUsers;

        }

        #endregion

        #region     Private Methods

        void Initialise()
        {
            //  Check if this machine is licensed
            CBLicense.CheckLicenseActivation();

            //  Initialise the HTTP Client
            CBLApiHelper.InitializeCBLClient(CBLHTTPClientUri());

            //  Initialise the Azure Client
            CBLApiHelper.InitializeAzureClient(AzureHTTPClientUri());
        }

        string SerializeUserData()
        {
            UserValidation uv = new UserValidation();

            uv.accountAlias = "commandrooms";
            uv.email = CBLicense.LexLicense.CBLUsername;
            uv.password = CBLicense.LexLicense.CBLPassword;

            return JsonConvert.SerializeObject(uv);
        }

        string SerializePasswordResetData()
        {
            PasswordResetRequest req = new PasswordResetRequest();

            req.newPassword = PasswordGenerator.GeneratePassword(true, true, true, true, false, 10);
            req.token = CBLicense.LexLicense.CBLPasswordToken.resetPasswordToken;

            return JsonConvert.SerializeObject(req);
        }

        string SerializeAccessTokenRequest()
        {
            PersonalAccessToken token = new PersonalAccessToken();
            string[] scopearray = new string[] { "account:read", "account:write", "user:read", "user:write", "personalAccessToken:write" };

            token.name = "brandnewtoken";
            token.expiresAt = DateTime.Now.AddMinutes(10).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            token.scopes = scopearray;

            return JsonConvert.SerializeObject(token);
        }

        Uri CBLHTTPClientUri()
        {
            List<SettingsParameter> paramList = dataAccess.LoadSettings(QueryStringLibrary.QS_LoadSettingsParameters());

            return new Uri(paramList.Where(p => p.Name == "LexUri").First().StringValue);

        }

        Uri AzureHTTPClientUri()
        {
            List<SettingsParameter> paramList = dataAccess.LoadSettings(QueryStringLibrary.QS_LoadSettingsParameters());

            return new Uri(paramList.Where(p => p.Name == "AzureUri").First().StringValue);

        }

        #endregion
    }
}
