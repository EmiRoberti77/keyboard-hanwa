using System;

namespace CommaBoard.Store.Class
{
    public class PingResult
    {

        public string error { get; set; }
        public string errorString { get; set; }
        public PingReply reply { get; set; }

    }

    public class PingReply
    {
        
        public Guid moduleGuid { get; set; }
        public Guid localSystemId { get; set; }
        public int sysIdTime { get; set; }
        
       
    }
}
