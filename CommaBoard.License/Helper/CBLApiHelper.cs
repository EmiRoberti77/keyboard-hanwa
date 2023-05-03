using System;
using System.Collections.Generic;
using System.ComponentModel;
using NLog;
using System.Net.Http;
using System.Net.Http.Headers;
using CommaBoard.Store.Static;
using System.Reflection;

namespace CommaBoard.License.Helper
{
    public class CBLApiHelper
    {

        public static HttpClient ApiClient { get; set; }

        public static HttpClient TokenClient { get; set; }

        public static HttpClientHandler Handler { get; set; }

        public static Uri CBLUri { get; set; }

        public static Uri AzureUri { get; set; }


        public static string CBLAccessToken = "";

        public static void InitializeCBLClient(Uri uri)
        {

            try
            {
                CBLUri = uri;
                Handler = new HttpClientHandler();
                Handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                ApiClient = new HttpClient(Handler);
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CBLAccessToken);
                ApiClient.BaseAddress = uri;

                Log.InfoMessage("Cryptlex API HTTP Client initialised", MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                Log.ErrorMessage(ex, "LexApiHelper - InitializeClient", MethodBase.GetCurrentMethod().Name);
            }

        }

        public static void InitializeAzureClient(Uri uri)
        {

            try
            {
                AzureUri = uri;
                Handler = new HttpClientHandler();
                Handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                TokenClient = new HttpClient(Handler);
                TokenClient.DefaultRequestHeaders.Accept.Clear();
                TokenClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                TokenClient.BaseAddress = uri;

                Log.InfoMessage("Azure API HTTP Client initialised", MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                Log.ErrorMessage(ex, "LexApiHelper - InitializeAzureClient", MethodBase.GetCurrentMethod().Name);
            }

        }

    }
}
