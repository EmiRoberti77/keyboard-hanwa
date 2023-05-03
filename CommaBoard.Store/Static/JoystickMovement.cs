using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.Store.Static
{
    public static class JoystickMovement
    {
        
        public static string PanDirection { get; set; }

        public static int PanValue { get; set; }

        public static string TiltDirection { get; set; }

        public static int TiltValue { get; set; }

        public static bool AtRest { get; set; } = true;

        public static string ZoomDirection { get; set; }

        public static int ZoomValue { get; set; }

        public static bool ZoomStop { get; set; } = true;


    }
}
