using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommaBoard.Store.Class;
using CommaBoard.Store.Interface;
using CommaBoard.Store.Library;
using CommaBoard.Store.Static;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace CommaBoard.Comms
{
    public class CBClientHTTP : ICBClient
    {

        #region     Public Properties

        public string ApiCommand { get; set; }
        public string ApiMessage { get; set; }

        #endregion

        #region     Constructor

        public CBClientHTTP()
        {  }

        #endregion

        #region     Public Methods

        public void Close()
        {
            throw new NotImplementedException();
        }

        public bool IsConnected()
        {
            //ApiCommand = "api/ping";
            //Task<string> ping = TestConnectionWithPing();
            //Task.WhenAll(ping);

            //ViewDisplay.UniversalMessage(ping.Result, true, Store.Enum.SettingsType.Connection);

            //if (ping.Result.IndexOf("error") != -1) return false;

            return true;
        }

        public string Login(List<ISettingsParameter> ConnectionParameters)
        {
            throw new NotImplementedException();
        }

        public string Open(List<SettingsParameter> ConnectionParameters)
        {
            throw new NotImplementedException();
        }

        public void Receive()
        {
            throw new NotImplementedException();
        }

        public void Send(string data)
        {
            //  Not yet implemented
        }

        public async Task<string> SendHTTP()
        {
            return await SendPutRequest();
        }

        public async Task<string> SendPost()
        {
            return await SendPostRequest();
        }

        public async Task<string> GetCameraList()
        {
            return await SendGetCamerasRequest();
        }

        public async Task<string> GetLayoutList()
        {
            return await SendGetLayoutsRequest();
        }

        public async Task<string> TestConnectionWithPing()
        {
            return await SendPingRequest();
        }
        
        #endregion

        #region     Private HTTP Methods

        /// <summary>
        /// Request a list of cameras from the server
        /// but only those with a Logical id
        /// </summary>
        /// <returns></returns>
        async Task<string> SendGetCamerasRequest()
        {
            try
            {
                Wave.Grid.CameraControlCameraList = new MvxObservableCollection<Camera>();
                MvxObservableCollection<Camera> temp = new MvxObservableCollection<Camera>();

                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiCommand))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Convert response content to List of Cameras
                        temp = JsonConvert.DeserializeObject<MvxObservableCollection<Camera>>(await response.Content.ReadAsStringAsync());

                        //  Build a Camera List of all Cameras with a number string as Logical Id
                        foreach (var cam in temp)
                        {
                            if (cam.logicalId != "0" && cam.logicalId != "") Wave.Grid.CameraControlCameraList.Add(cam);
                        }

                        //  Return a successful message
                        return GeneralTextLibrary.CAMERA_LIST_SUCCESSFULLY_REQUESTED;

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.CAMERA_LIST_ERROR}\n\rERROR: " + response.ReasonPhrase;
                    }
                }
            }
            catch (Exception ex)
            {
                //  Log this error fully
                Log.ErrorMessage(ex, GeneralTextLibrary.CAMERA_LIST_ERROR);

                return $"{GeneralTextLibrary.CAMERA_LIST_ERROR}\n\rERROR: {ex.Message}";

            }

        }

        /// <summary>
        /// Request a list of layouts from the server
        /// but only those with a Logical Id
        /// </summary>
        /// <returns></returns>
        async Task<string> SendGetLayoutsRequest()
        {        
            try
            {
                Wave.Grid.LayoutControlLayoutList = new MvxObservableCollection<Layout>();
                MvxObservableCollection<Layout> temp1 = new MvxObservableCollection<Layout>();

                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiCommand))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        //  Convert response content to List of Layouts
                        temp1 = JsonConvert.DeserializeObject<MvxObservableCollection<Layout>>(await response.Content.ReadAsStringAsync());

                        // Build a Layout List of all Layouts with a Logical Id > zero
                        foreach (var lay in temp1)
                        {
                            if (lay.logicalId != 0) Wave.Grid.LayoutControlLayoutList.Add(lay);
                        }


                        //  Return a successful message
                        return GeneralTextLibrary.LAYOUT_LIST_SUCCESSFULLY_REQUESTED;

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.LAYOUT_LIST_ERROR}\n\rERROR: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"{GeneralTextLibrary.LAYOUT_LIST_ERROR}\n\rERROR: {ex.Message}";
            }

        }

        /// <summary>
        /// Generic method to send any HTTP PUT request
        /// </summary>
        /// <returns></returns>
        async Task<string> SendPutRequest()
        {
            var content = new StringContent(ApiMessage, Encoding.UTF8, "application/json");

            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(ApiCommand, content))
                {

                    if (response.IsSuccessStatusCode)
                    {

                        return GeneralTextLibrary.HTTP_PUT_REQUEST_SUCCESSFUL;

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.HTTP_PUT_REQUEST_ERROR}\r\nERROR: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"{GeneralTextLibrary.HTTP_PUT_REQUEST_ERROR}\r\nERROR: {ex.Message}";
            }



        }

        /// <summary>
        /// Generic method to send any HTTP POST request
        /// </summary>
        /// <returns></returns>
        async Task<string> SendPostRequest()
        {
            var content = new StringContent(ApiMessage, Encoding.UTF8, "application/json");

            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(ApiCommand, content))
                {

                    if (response.IsSuccessStatusCode)
                    {

                        return GeneralTextLibrary.HTTP_POST_REQUEST_SUCCESSFUL;

                    }
                    else
                    {
                        return $"{GeneralTextLibrary.HTTP_POST_REQUEST_ERROR}\r\nERROR: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"{GeneralTextLibrary.HTTP_POST_REQUEST_ERROR}\r\nERROR: {ex.Message}";
            }



        }

        /// <summary>
        /// Test the HTTP server with a ping request
        /// </summary>
        /// <returns></returns>
        async Task<string> SendPingRequest()
        {
            PingResult pingResult = new PingResult();

            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiCommand))
                {
                    
                    if (response.IsSuccessStatusCode)
                    {
                        //  Convert response content to List of Cameras
                        pingResult = JsonConvert.DeserializeObject<PingResult>(await response.Content.ReadAsStringAsync());

                        if(pingResult.error == "0")
                        {
                            return "Ping returned successfully.";
                        }

                        return $"Ping error code not zero. ErrorCode: { pingResult.error} ErrorString { pingResult.errorString }";
                    }
                    else
                    {
                        return "Error returning Ping.\n\rERROR: " + response.ReasonPhrase;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error calling available cameras.\n\rERROR: " + ex.Message;

            }
        }

        #endregion

    }
}
