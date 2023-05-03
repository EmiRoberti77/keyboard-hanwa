using System;
using System.Collections.Generic;
using System.Text;
using CommaBoard.Store.Interface;

namespace CommaBoard.Store.Class
{
    public class CommaBoardButton : ICommaBoardButton
    {
        public int Id { get; }

        public string Name { get; set; }

        public bool Buffer { get; set; }

        public bool SendData { get; set; }

        public bool ClickAndRelease { get; set; }

        public bool RequiresNumber { get; set; }

        public string Value { get; set; }

        public static List<CommaBoardButton> DBCommaBoardButtonList { get; set; }

        public static List<ICommaBoardButton> BufferButtonList { get; set; }

        public static ICommaBoardButton GreenCommandButton { get; set; }

        public static void ClearCommaBoardButtonList()
        {
            BufferButtonList = new List<ICommaBoardButton>();
        }



    }
}
