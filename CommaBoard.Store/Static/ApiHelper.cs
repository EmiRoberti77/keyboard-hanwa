using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

namespace CommaBoard.Store.Static
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static HttpClientHandler Handler { get; set; }

        public static Uri Uri { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }

        public static void InitializeClient(Uri uri, string username, string password)
        {
            
            try
            {
                Uri = uri;
                Username = username;
                Password = password;

                Handler = new HttpClientHandler();
                Handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                Handler.Credentials = new NetworkCredential(Username, Password);
                ApiClient = new HttpClient(Handler);
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ApiClient.BaseAddress = uri;

                Log.InfoMessage("HTTP Client initialised", MethodBase.GetCurrentMethod().Name);
            }
            catch(Exception ex)
            {
                Log.ErrorMessage(ex, "ApiHelper - InitializeClient", MethodBase.GetCurrentMethod().Name);
            }
            
        }
    }


}

