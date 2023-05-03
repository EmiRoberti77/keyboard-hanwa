using MvvmCross.ViewModels;

namespace CommaBoard.Store.Static
{
    public static class ControlVisible
    {
        static UserControlVisible ucVisible = new UserControlVisible();

        public static UserControlVisible UCVisible
        {
            get
            {
                return ucVisible;
            }
        }

    }

    public  class UserControlVisible : MvxNotifyPropertyChanged
    {

        bool _layoutNotCreated;
        public bool LayoutNotCreated
        {
            get { return _layoutNotCreated; }

            set { SetProperty(ref _layoutNotCreated, value); }
        }

        bool _layoutCreated;
        public bool LayoutCreated
        {
            get { return _layoutCreated; }

            set { SetProperty(ref _layoutCreated, value); }
        }

        bool _liveViewEnabled;
        public bool LiveViewEnabled
        {
            get { return _liveViewEnabled; }

            set { SetProperty(ref _liveViewEnabled, value); }
        }

        bool _layoutViewEnabled;
        public bool LayoutViewEnabled
        {
            get { return _layoutViewEnabled; }

            set { SetProperty(ref _layoutViewEnabled, value); }
        }

        bool _startRecordingEnabled;
        public bool StartRecordingEnabled
        {
            get { return _startRecordingEnabled; }

            set { SetProperty(ref _startRecordingEnabled, value); }
        }

        bool _stopRecordingEnabled;
        public bool StopRecordingEnabled
        {
            get { return _stopRecordingEnabled; }

            set { SetProperty(ref _stopRecordingEnabled, value); }
        }

        bool _layoutMoveEnabled;
        public bool LayoutMoveEnabled
        {
            get { return _layoutMoveEnabled; }

            set { SetProperty(ref _layoutMoveEnabled, value); }
        }

        bool _resourcesVisible;
        public bool ResourcesVisible
        {
            get { return _resourcesVisible; }

            set { SetProperty(ref _resourcesVisible, value); }
        }

        bool _playbackVisible;
        public bool PlaybackVisible
        {
            get { return _playbackVisible; }

            set { SetProperty(ref _playbackVisible, value); }
        }

        bool _settingsButtonVisible;
        public bool SettingsButtonVisible
        {
            get { return _settingsButtonVisible; }

            set { SetProperty(ref _settingsButtonVisible, value); }
        }

    }

    public static class UserType
    {
        static User _admin = new User();

        public static User Admin
        {
            get
            {
                return _admin;
            }
        }
    }

    public class User : MvxNotifyPropertyChanged
    {
        bool _loggedIn;
        public bool LoggedIn
        {
            get { return _loggedIn; }

            set { SetProperty(ref _loggedIn, value); }
        }
    }


}
