using CommaBoard.License.Class;
using CommaBoard.License.Helper;
using CommaBoard.License.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommaBoard.License.Client
{
    public class AzureClient
    {

        #region     Public Properties

        public string ApiCommand { get; set; }

        public string ApiMessage { get; set; }

        #endregion

        #region     Constructor

        public AzureClient()
        {
            //  Initialise the HTTP Client
            CBLApiHelper.TokenClient = new HttpClient();
        }

        #endregion

        #region     Public Methods

        public async Task<string> GetAccessToken()
        {
            return await SendAccessTokenRequest();
        }

        #endregion

        #region     Private Azure API Methods

        async Task<string> SendAccessTokenRequest()
        {
            try
            {

                using (HttpResponseMessage response = await CBLApiHelper.TokenClient.PostAsync(ApiCommand,null))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Request successful, User logged in and Access Token collected
                        CBLicense.UserAccessToken = JsonConvert.DeserializeObject<AccessToken>(await response.Content.ReadAsStringAsync());

                        //  Return a successful message
                        return "User successfully validated.";

                    }
                    else
                    {
                        return "Error validating user.\n\rERROR: " + response.ReasonPhrase;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error validating user.\n\rERROR: " + ex.Message;

            }

        }

        #endregion


    }
}
