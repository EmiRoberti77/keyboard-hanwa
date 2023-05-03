using CommaBoard.Store.Class;
using System.Collections.Generic;
using System.Timers;

namespace CommaBoard.Store.Library
{
    public static class ShortcutLibrary
    {

        public static string ReturnShortcutCommandFromButtonName(string buttonname)
        {
            switch(buttonname)
            {
                /*
                       For SHIFT use +
                       For CTRL use ^
                       For ALT use % 
                   */

                //  Move to the Previous Layout Tab
                case "sc_PrevLayout":
                    return "+^{TAB}";

                //  Move to the Next Layout Tab
                case "sc_NextLayout":
                    return "^{TAB}";

                //  Create a new layout tab
                case "sc_NewLayout":
                    return "^(t)";
                
                //  Toggle the PTZ option for the current camera
                case "sc_TogglePTZ":
                    return "(p)";

                //  Save the current layout as a new name
                case "sc_SaveLayoutAs":
                    return "^+(s)";

                //  Highlight the previous camera in the layout
                case "sc_PrevCamera":
                    return "+{LEFT}";
                
                //  Highlight the next camera in the layout
                case "sc_NextCamera":
                    return "+{RIGHT}";

                //  Toggle between camera in full screen and back in layout
                case "sc_ToggleFSMonitor":
                    return "{F11}";

                case "sc_ToggleFSCamera":
                    return "{ENTER}";

                case "sc_ZoomIn":
                    return "{+}";

                case "sc_ZoomOut":
                    return "(-)";

                case "sc_ToggleDewarp":
                    return "d";

                //  MISC CONTROLS
                case "sc_GrabImage":
                    return "%(s)";

                case "sc_SaveImage":
                    return "{ENTER}";

                case "sc_StartRecording":
                    return "%(r)";

                case "sc_StopRecording":
                    return "%(r)";

                case "sc_SaveRecording":
                    return "{ENTER}";

                case "sc_OpenInfo":
                    return "^(m)";

                case "sc_CloseInfo":
                    return "{ESC}";

                case "sc_VolumeMinus":
                    return "^{DOWN}";

                case "sc_VolumePlus":
                    return "^{UP}";

                case "sc_VolumeMute":
                    return "u";

                case "sc_Live":
                    return "l";

                //  PLAYBACK CONTROLS
                case "sc_PlayPause":
                    return " ";

                case "sc_SlowDownPlayback":
                    return "^{LEFT}";

                case "sc_SpeedUpPlayback":
                    return "^{RIGHT}";

                case "sc_PreviousChunk":
                    return "z";

                case "sc_NextChunk":
                    return "x";

                case "sc_ArchiveStart":
                    return "[";

                case "sc_ArchiveEnd":
                    return "]";

                case "sc_Sync":
                    return "s";

            }

            return "";
        }

    }
}
