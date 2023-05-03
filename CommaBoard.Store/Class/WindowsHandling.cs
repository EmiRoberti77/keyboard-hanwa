using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using CommaBoard.Store.Static;
using System.Windows.Forms;

public class WindowHandling
{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int SetForegroundWindow(IntPtr hwnd);

    private enum ShowWindowEnum
    {
        Hide = 0,
        ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
        Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
        Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
        Restore = 9, ShowDefault = 10, ForceMinimized = 11
    };

    public string BringMainWindowToFront()
    {
        List<Process> pList = new List<Process>();
        try
        {
            string processName = "Wisenet WAVE";

            // Retrieve all the Wave processes open
            Process[] processarray = Process.GetProcessesByName(processName);

            //  Bail out if there are none
            if (processarray.Length == 0)
            {
                return $"Error: No processes found with name {processName}.";
            }

            if (Display.Numbers.NumberShortcutTarget > processarray.Length) Display.Numbers.NumberShortcutTarget = 0;

            Process bProcess = processarray[Display.Numbers.NumberShortcutTarget];

            // check if the process is running
            if (bProcess != null)
            {
                // check if the window is hidden / minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    // the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.Restore);
                }

                // set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
            }
            else
            {
                // the process is not running, so start it
                Process.Start(processName);
            }

            return "";
        }
        catch (Exception ex)
        {
            return $"Exception Error: {ex.Message}.";
        }

    }

    public void TargetWindowByHandle(IntPtr handle)
    {
        SetForegroundWindow(handle);
    }

    public void BringApplicationToFrontAndSendKeyboardShortcut(string name, string shortcut)
    {
        Process[] p = Process.GetProcessesByName(name);

        // Activate the first application we find with this name
        if (p.Count() > 0)
            SetForegroundWindow(p[0].MainWindowHandle);

        SendKeys.SendWait(shortcut);
    }
    
}
