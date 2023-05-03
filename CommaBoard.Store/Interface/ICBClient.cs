using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommaBoard.Store.Class;

namespace CommaBoard.Store.Interface
{
    public interface ICBClient
    {

        string ApiCommand { get; set; }

        string ApiMessage { get; set; }

        bool IsConnected();

        string Open(List<SettingsParameter> ConnectionParameters);

        string Login(List<ISettingsParameter> ConnectionParameters);

        void Send(string data);

        Task<string> SendHTTP();

        Task<string> SendPost();

        void Close();

        void Receive();

        Task<string> GetCameraList();

        Task<string> GetLayoutList();

    }
}
