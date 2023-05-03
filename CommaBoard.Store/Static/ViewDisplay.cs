
using MvvmCross.ViewModels;
using System.Windows.Media;
using CommaBoard.Store.Enum;
using System.Collections.Generic;
using NLog;
using System;

namespace CommaBoard.Store.Static
{
    public static class ViewDisplay
    {

        #region     Static Class Initialisation

        static NoticeDisplay messages = new NoticeDisplay();

        public static NoticeDisplay Messages
        {
            get
            {
                return messages;
            }
        }

        #endregion

        #region     Public Static Methods

        public static void DisplayViewErrorMessage(Exception ex, string message)
        {
            Messages.ViewMessageForeground = Brushes.Red;

            Messages.ViewMessageContent = $"{message} Exception error: {ex.Message}";
        }

        public static void DisplayViewWarningMessage(string message)
        {
            Messages.ViewMessageForeground = Brushes.Red;

            Messages.ViewMessageContent = message;
        }

        public static void DisplayViewInfoMessage(string message)
        {
            Messages.ViewMessageForeground = Brushes.Black;

            Messages.ViewMessageContent = message;
        }

        #endregion

    }

    public class NoticeDisplay : MvxNotifyPropertyChanged
    {

        #region     Public Properties

        Brush _viewMessageForeground;
        public Brush ViewMessageForeground
        {
            get { return _viewMessageForeground; }

            set { SetProperty(ref _viewMessageForeground, value); }
        }

        string _viewMessageContent;
        public string ViewMessageContent
        {
            get { return _viewMessageContent; }

            set { SetProperty(ref _viewMessageContent, value); }
        }
        #endregion

    }


}
