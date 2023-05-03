using System;


namespace CommaBoard.Store.Class
{
    public class DataReceivedArgs : EventArgs
    {
        public string Data { get; set; }
    }

    public class ConnectionBreakArgs : EventArgs
    {
        public string Reason { get; set; }
    }
}
