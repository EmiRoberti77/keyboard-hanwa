
using System.Windows.Media;
using MvvmCross.ViewModels;
using System.Timers;
using System;

namespace CommaBoard.Store.Static
{
    public static class Display
    {

        static NumberDisplay numbers = new NumberDisplay();

        public static NumberDisplay Numbers
        {
            get
            {
                return numbers;
            }
        }

        static Timer displayTimer;

        static int timerInterval = 1000;

        static PanelDisplay panels = new PanelDisplay();

        public static PanelDisplay Panels
        {
            get
            {
                return panels;
            }
        }

        public static string ButtonsPressedString { get; set; } = "";

        public static void ClearBuffer()
        {
            Numbers.NumberBuffer = "";

            Numbers.NumberDisplayNumber = 0;
        }

        public static void ClearLabelHighlight()
        {
            Numbers.MonitorForeground = Brushes.White;
            Numbers.CameraForeground = Brushes.White;
            Numbers.LayoutForeground = Brushes.White;

            Numbers.MonitorHighlighted = false;
            Numbers.CameraHighlighted = false;
            Numbers.LayoutHighlighted = false;
        }

        public static void HighlightLabel(string name)
        {
            switch (name)
            {
                case "Monitor":
                    Numbers.MonitorForeground = Brushes.Yellow;
                    Numbers.MonitorHighlighted = true;
                    break;

                case "Camera":
                    Numbers.CameraForeground = Brushes.Yellow;
                    Numbers.CameraHighlighted = true;
                    break;

                case "Layout":
                    Numbers.LayoutForeground = Brushes.Yellow;
                    Numbers.LayoutHighlighted = true;
                    break;
            }
        }

        public static void SetShortcutTarget()
        {

            switch (Numbers.NumberShortcutTarget)
            {
                case 0:
                    Numbers.ShortcutTargetText = "WAVE Client";
                    break;

                case 1:
                    Numbers.ShortcutTargetText = "WAVE Videowall";
                    break;
            }

        }

        public static void StartDisplayTimer()
        {
            displayTimer = new System.Timers.Timer(timerInterval);
            displayTimer.Elapsed += new ElapsedEventHandler(DisplayTimer_Tick);
            displayTimer.Enabled = true;
        }

        static void DisplayTimer_Tick(object source, ElapsedEventArgs e)
        {
            Numbers.DisplayDateString = DateTime.Now.ToString("dd-MM-yyyy");
            Numbers.DisplayTimeString = DateTime.Now.ToString("HH:mm");
        }


    }

    public class NumberDisplay : MvxNotifyPropertyChanged
    {

        private int _numberDisplayNumber;
        public int NumberDisplayNumber
        {
            get { return _numberDisplayNumber; }

            set { SetProperty(ref _numberDisplayNumber, value); }
        }

        private int _numberDisplayMonitor;
        public int NumberDisplayMonitor
        {
            get { return _numberDisplayMonitor; }

            set { SetProperty(ref _numberDisplayMonitor, value); }
        }

        private int _numberDisplayQuadrant;
        public int NumberDisplayQuadrant
        {
            get { return _numberDisplayQuadrant; }

            set { SetProperty(ref _numberDisplayQuadrant, value); }
        }

        private int _numberDisplayCamera;
        public int NumberDisplayCamera
        {
            get { return _numberDisplayCamera; }

            set { SetProperty(ref _numberDisplayCamera, value); }
        }

        private int _numberDisplayLayout;
        public int NumberDisplayLayout
        {
            get { return _numberDisplayLayout; }

            set { SetProperty(ref _numberDisplayLayout, value); }
        }

        private string _numberBuffer;
        public string NumberBuffer
        {
            get { return _numberBuffer; }

            set { SetProperty(ref _numberBuffer, value); }
        }

        private Brush _monitorForeground;
        public Brush MonitorForeground
        {
            get { return _monitorForeground; }

            set { SetProperty(ref _monitorForeground, value); }
        }

        private Brush _cameraForeground;
        public Brush CameraForeground
        {
            get { return _cameraForeground; }

            set { SetProperty(ref _cameraForeground, value); }
        }

        private Brush _layoutForeground;
        public Brush LayoutForeground
        {
            get { return _layoutForeground; }

            set { SetProperty(ref _layoutForeground, value); }
        }

        private bool _monitorHighlighted;
        public bool MonitorHighlighted
        {
            get { return _monitorHighlighted; }

            set { SetProperty(ref _monitorHighlighted, value); }
        }

        private bool _cameraHighlighted;
        public bool CameraHighlighted
        {
            get { return _cameraHighlighted; }

            set { SetProperty(ref _cameraHighlighted, value); }
        }

        private bool _layoutHighlighted;
        public bool LayoutHighlighted
        {
            get { return _layoutHighlighted; }

            set { SetProperty(ref _layoutHighlighted, value); }
        }

        string _buttonPressedText;
        public string ButtonPressedText
        {
            get { return _buttonPressedText; }

            set { SetProperty(ref _buttonPressedText, value); }
        }

        string _monitorDisplayText;
        public string MonitorDisplayText
        {
            get { return _monitorDisplayText; }

            set { SetProperty(ref _monitorDisplayText, value); }
        }

        string _cameraDisplayText;
        public string CameraDisplayText
        {
            get { return _cameraDisplayText; }

            set { SetProperty(ref _cameraDisplayText, value); }
        }

        private int _numberShortcutTarget;
        public int NumberShortcutTarget
        {
            get { return _numberShortcutTarget; }

            set { SetProperty(ref _numberShortcutTarget, value); }
        }

        string _shortcutTargetText;
        public string ShortcutTargetText
        {
            get { return _shortcutTargetText; }

            set { SetProperty(ref _shortcutTargetText, value); }
        }

        string _displayDateString;
        public string DisplayDateString
        {
            get { return _displayDateString; }

            set { SetProperty(ref _displayDateString, value); }
        }

        string _displayTimeString;
        public string DisplayTimeString
        {
            get { return _displayTimeString; }

            set { SetProperty(ref _displayTimeString, value); }
        }

    }

    public class PanelDisplay : MvxNotifyPropertyChanged
    {
        private int _panel01Column;
        public int Panel01Column
        {
            get { return _panel01Column; }

            set { SetProperty(ref _panel01Column, value); }
        }

        private int _panel02Column;
        public int Panel02Column
        {
            get { return _panel02Column; }

            set { SetProperty(ref _panel02Column, value); }
        }

        private int _panel03Column;
        public int Panel03Column
        {
            get { return _panel03Column; }

            set { SetProperty(ref _panel03Column, value); }
        }

        private int _panel04Column;
        public int Panel04Column
        {
            get { return _panel04Column; }

            set { SetProperty(ref _panel02Column, value); }
        }
    }


}
