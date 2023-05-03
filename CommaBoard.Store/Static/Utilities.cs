using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.Store.Static
{
    public static class Utilities
    {
        /// <summary>
        /// Display and log a basic Info message
        /// </summary>
        /// <param name="msg">The info message to log and display</param>
        public static void LogAndDisplayInfo(string msg)
        {
            Log.InfoMessage(msg);
            ViewDisplay.DisplayViewInfoMessage(msg);
        }

        /// <summary>
        /// Display and log a Warning message
        /// </summary>
        /// <param name="msg">The warning message to log and display</param>
        public static void LogAndDisplayWarning(string msg)
        {
            Log.WarningMessage(msg);
            ViewDisplay.DisplayViewWarningMessage(msg);
        }

        /// <summary>
        /// Display and log an exceptio Error message
        /// </summary>
        /// <param name="ex">The exception error</param>
        /// <param name="msg">Accompanying message</param>
        public static void LogAndDisplayError(Exception ex, string msg)
        {
            Log.ErrorMessage(ex, msg);
            ViewDisplay.DisplayViewErrorMessage(ex, msg);
        }
    }
}
