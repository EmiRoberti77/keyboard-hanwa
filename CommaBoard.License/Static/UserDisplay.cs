using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.License.Static
{
    public static class UserDisplay
    {

        static CBLUserData cblUser = new CBLUserData();

        public static CBLUserData CBLUser
        {
            get
            {
                return cblUser;
            }
        }

        public static void DisplayUserLoggedIn()
        {
            //  Display the initial Logged In Text
            CBLUser.LoggedInText = $"Currently logged in: {CBLicense.LexLicense.CurrentUserLoggedIn.firstName}";
            CBLUser.LocationNote = $"Add User to this location - {CBLicense.LexLicense.CurrentUserLoggedIn.company} ";

            CBLUser.CancelLogoutButtonVisible = false;
            CBLUser.ConfirmLogoutButtonVisible = false;
            CBLUser.LogoutButtonVisible = true;
        }

        public static void ConfirmOrCancelUserLogout()
        {
            //  Display the initial Logged In Text
            CBLUser.LoggedInText = $"Confirm logout, {CBLicense.LexLicense.CurrentUserLoggedIn.firstName}";

            CBLUser.CancelLogoutButtonVisible = true;
            CBLUser.ConfirmLogoutButtonVisible = true;
            CBLUser.LogoutButtonVisible = false;
        }
    }

    public class CBLUserData : MvxNotifyPropertyChanged
    {
        string _loggedInText;
        public string LoggedInText
        {
            get { return _loggedInText; }

            set { SetProperty(ref _loggedInText, value); }
        }

        bool _logoutButtonVisible;
        public bool LogoutButtonVisible
        {
            get { return _logoutButtonVisible; }

            set { SetProperty(ref _logoutButtonVisible, value); }
        }

        bool _confirmLogoutButtonVisible;
        public bool ConfirmLogoutButtonVisible
        {
            get { return _confirmLogoutButtonVisible; }

            set { SetProperty(ref _confirmLogoutButtonVisible, value); }
        }

        bool _cancelLogoutButtonVisible;
        public bool CancelLogoutButtonVisible
        {
            get { return _cancelLogoutButtonVisible; }

            set { SetProperty(ref _cancelLogoutButtonVisible, value); }
        }

        string _locationNote;
        public string LocationNote
        {
            get { return _locationNote; }

            set { SetProperty(ref _locationNote, value); }
        }

    }
}
