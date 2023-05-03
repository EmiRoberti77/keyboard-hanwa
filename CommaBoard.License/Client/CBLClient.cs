using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommaBoard.License.Class;
using CommaBoard.License.Helper;
using CommaBoard.License.Static;
using CommaBoard.Store.Library;
using CommaBoard.Store.Static;
using Newtonsoft.Json;

namespace CommaBoard.License.Client
{
    public class CBLClient
    {

        #region     Public Properties

        public string ApiCommand { get; set; }

        public string ApiMessage { get; set; }

        #endregion

        #region     Public Methods

        /// <summary>
        /// Request a full list of Users at this location
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetUserList()
        {
            return await SendGetUsersRequest();
        }

        /// <summary>
        /// Validate User from Login credentials
        /// </summary>
        /// <returns></returns>
        public async Task<string> ValidateUser()
        {
            return await SendValidateUserRequest();
        }

        /// <summary>
        /// Request the full profile of the User currently logged in
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetCurrentUser()
        {
            return await SendRetrieveProfileRequest();
        }

        /// <summary>
        /// Request a password reset token
        /// required before a reset request can be sent
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPasswordResetToken()
        {
            return await SendGetPasswordResetToken();
        }

        /// <summary>
        /// Send a password reset request
        /// </summary>
        /// <returns></returns>
        public async Task<string> ResetPassword()
        {
            return await SendResetPasswordRequest();
        }

        /// <summary>
        /// Create a new User for this location
        /// </summary>
        /// <returns></returns>
        public async Task<string> CreateUser()
        {
            return await SendCreateUserRequest();
        }


        #endregion

        #region     Constructor

        public CBLClient()
        { 
            //  Initialise the HTTP Client
            CBLApiHelper.ApiClient = new HttpClient(); 
        }

        #endregion

        #region     Private Cryptlex API HTTP Methods

        /// <summary>
        /// Get a list of ALL Users at this location
        /// </summary>
        /// <returns></returns>
        async Task<string> SendGetUsersRequest()
        {
            try
            {
                CBLicense.LexLicense.CommaBoardUsers = new List<CBLUser>();

                CBLApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CBLicense.UserAccessToken.accessToken);

                using (HttpResponseMessage response = await CBLApiHelper.ApiClient.GetAsync(ApiCommand))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Convert response content to List of Cameras
                        CBLicense.LexLicense.CommaBoardUsers = JsonConvert.DeserializeObject<List<CBLUser>>(await response.Content.ReadAsStringAsync());

                        //  Return a successful message
                        return GeneralTextLibrary.COMMABOARD_LICENSE_USER_LIST_SUCCESSFUL;

                    }
                    else
                    {
                        CBLicense.LexLicense.CBLErrorMessage = JsonConvert.DeserializeObject<ErrorMessage>(await response.Content.ReadAsStringAsync());
                        return $"{GeneralTextLibrary.COMMABOARD_LICENSE_USER_LIST_ERROR}\n\rERROR: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                //  Log this exception error fully
                Log.ErrorMessage(ex, GeneralTextLibrary.COMMABOARD_LICENSE_USER_LIST_ERROR);

                return $"{GeneralTextLibrary.COMMABOARD_LICENSE_USER_LIST_ERROR}\n\rERROR: {ex.Message}";
            }

        }

        /// <summary>
        /// Get the full User profile of the person logged in
        /// </summary>
        /// <returns></returns>
        async Task<string> SendRetrieveProfileRequest()
        {
            try
            {
                CBLicense.LexLicense.CurrentUserLoggedIn = new CBLUser();

                CBLApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CBLicense.ProfileAccessToken.accessToken);

                using (HttpResponseMessage response = await CBLApiHelper.ApiClient.GetAsync(ApiCommand))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Load the full profile of the current logged in user
                        CBLicense.LexLicense.CurrentUserLoggedIn = JsonConvert.DeserializeObject<CBLUser>(await response.Content.ReadAsStringAsync());

                        //  Establish whether this is an Admin User
                        CBLicense.LexLicense.CurrentUserIsAdmin = UserIsAdmin();

                        //  Return a successful message
                        return $"Profile retrieved for {CBLicense.LexLicense.CurrentUserLoggedIn.firstName}.";

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.COMMABOARD_LICENSE_USER_PROFILE_ERROR}\n\rERROR: {response.ReasonPhrase}";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                //  Log this exception error fully
                Log.ErrorMessage(ex, GeneralTextLibrary.COMMABOARD_LICENSE_USER_PROFILE_ERROR);

                return $"{GeneralTextLibrary.COMMABOARD_LICENSE_USER_PROFILE_ERROR}\n\rERROR: {ex.Message}";
            }

        }

        /// <summary>
        /// Validate the User by their email and password
        /// </summary>
        /// <returns></returns>
        async Task<string> SendValidateUserRequest()
        {
            try
            {
                var content = new StringContent(ApiMessage, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await CBLApiHelper.ApiClient.PostAsync(ApiCommand, content))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Request successful, User logged in and Access Token collected
                        CBLicense.ProfileAccessToken = JsonConvert.DeserializeObject <AccessToken>(await response.Content.ReadAsStringAsync());

                        //  Return a successful message
                        return GeneralTextLibrary.COMMABOARD_LICENSE_USER_VALIDATION_SUCCESSFUL;

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.COMMABOARD_LICENSE_USER_VALIDATION_ERROR}\n\rERROR: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                //  Log this exception error fully
                Log.ErrorMessage(ex, GeneralTextLibrary.COMMABOARD_LICENSE_USER_VALIDATION_ERROR);

                return $"{GeneralTextLibrary.COMMABOARD_LICENSE_USER_VALIDATION_ERROR}\n\rERROR: {ex.Message}";
            }

        }

        /// <summary>
        /// Get the password reset token needed for a password reset request
        /// </summary>
        /// <returns></returns>
        async Task<string> SendGetPasswordResetToken()
        {
            try
            {
                using (HttpResponseMessage response = await CBLApiHelper.ApiClient.PostAsync(ApiCommand, null))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Request successful, User logged in and Access Token collected
                        CBLicense.LexLicense.CBLPasswordToken = JsonConvert.DeserializeObject<PasswordToken>(await response.Content.ReadAsStringAsync());

                        //  Return a successful message
                        return GeneralTextLibrary.COMMABOARD_LICENSE_PASSWORD_TOKEN_SUCCESSFUL;

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.COMMABOARD_LICENSE_PASSWORD_TOKEN_ERROR}\n\rERROR: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                //  Log this exception error fully
                Log.ErrorMessage(ex, GeneralTextLibrary.COMMABOARD_LICENSE_PASSWORD_TOKEN_ERROR);

                return $"{GeneralTextLibrary.COMMABOARD_LICENSE_PASSWORD_TOKEN_ERROR}\n\rERROR: {ex.Message}";
            }

        }

        /// <summary>
        /// Send a password reset request resulting in an email sent to User
        /// </summary>
        /// <returns></returns>
        async Task<string> SendResetPasswordRequest()
        {
            try
            {
                var content = new StringContent(ApiMessage, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await CBLApiHelper.ApiClient.PostAsync(ApiCommand, content))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Request successful, User logged in and Access Token collected
                        CBLicense.LexLicense.CBLErrorMessage = JsonConvert.DeserializeObject<ErrorMessage>(await response.Content.ReadAsStringAsync());

                        //  Return a successful message
                        return $"Password reset email sent to { CBLicense.LexLicense.CurrentUserLoggedIn.email }";

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.COMMABOARD_LICENSE_PASSWORD_RESET_ERROR}\n\rERROR: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                //  Log this exception error fully
                Log.ErrorMessage(ex, GeneralTextLibrary.COMMABOARD_LICENSE_PASSWORD_RESET_ERROR);

                return $"{GeneralTextLibrary.COMMABOARD_LICENSE_PASSWORD_RESET_ERROR}\n\rERROR: {ex.Message}";
            }

        }

        /// <summary>
        /// Add a new User to list location
        /// </summary>
        /// <returns></returns>
        async Task<string> SendCreateUserRequest()
        {
            try
            {

                CBLApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CBLicense.UserAccessToken.accessToken);

                var content = new StringContent(ApiMessage, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await CBLApiHelper.ApiClient.PostAsync(ApiCommand, content))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Load the full profile of the current logged in user
                        CBLicense.LexLicense.NewUserAdded = JsonConvert.DeserializeObject<CBLUser>(await response.Content.ReadAsStringAsync());

                        //  Return a successful message
                        return $"New User added to location {CBLicense.LexLicense.CurrentUserLoggedIn.company}.";

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.COMMABOARD_LICENSE_USER_ADD_ERROR}\n\rERROR: {response.ReasonPhrase}";
                    }

                }
            }
            catch (Exception ex)
            {
                //  Log this exception error fully
                Log.ErrorMessage(ex, GeneralTextLibrary.COMMABOARD_LICENSE_USER_ADD_ERROR);

                return $"{GeneralTextLibrary.COMMABOARD_LICENSE_USER_ADD_ERROR}\n\rERROR: {ex.Message}";
            }
        }

        #endregion

        #region     Private Methods

        bool UserIsAdmin()
        {
            string status = CBLicense.LexLicense.CurrentUserLoggedIn.metadata[0].value;

            return status == "admin";
        }

        #endregion

    }
}
