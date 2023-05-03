using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.Store.Library
{
    public static class DisplayTextLibrary
    {
        #region     EMULATION NAME

        public static string EMULATION_NAME = "Wisenet WAVE";

        #endregion

        #region     NEW LINE

        const string NEWLINE = "\n\r";

        #endregion

        #region     VIEW MESSAGE CONTENT

        public const string INITIAL_VIEW_DISPLAY_MESSAGE = "CommaBoard will keep you informed of events." + NEWLINE + "This box will display progress, warning and error messages";

        #endregion

        #region     INTRO VIEW

        public static string INTRO_VIEW_TITLE = "Welcome To The CommaBoard " + EMULATION_NAME + " Emulation";

        public static string INTRO_BUTTON_CONTROL_TEXT = "Send touch screen commands to the " + EMULATION_NAME + " server/client";

        public const string INTRO_BUTTON_SETTINGS_TEXT = "Server connection settings and CommaBoard User settings";

        public const string INTRO_BUTTON_HELP_TEXT = "Help with using CommaBoard, including User Guide and tutorials";

        #endregion

        #region     SETTINGS VIEW

        public const string SETTINGS_VIEW_TITLE = "Welcome to the CommaBoard Settings page";
        
        public static string SETTINGS_VIEW_INFO_TEXT = "CommaBoard will attempt to connect to the " + EMULATION_NAME + " server on start up via the saved server credentials";
            
        #endregion

        #region     CONTROL VIEW

        public const string CONTROL_VIEW_TITLE = "Welcome to the CommaBoard Control page";

        public const string CONTROL_VIEW_INFO_TEXT = "";

        #endregion

        #region     HELP VIEW

        public const string HELP_VIEW_TITLE = "Welcome to the CommaBoard Help page";

        public const string HELP_VIEW_INFO_TEXT = "Here you will find help with the funtionality and operation of the CommaBoard application";

        #endregion

    }

    public static class LogTextLibrary
    {

        #region     NEW LINE

        const string NEWLINE = "\n\r";

        #endregion

        #region     APP.CS

        public const string APP_CS_BEGIN_COMMABOARD_STARTUP = NEWLINE + "BEGIN COMMABOARD STARTUP PROCESSES";         

        public const string APP_CS_COMPLETE_INTERFACE_LINKING = NEWLINE + "Interface linking completed";
            
        public const string APP_CS_ERROR_IN_INTERFACE_LINKING = NEWLINE + "Eror linking Interfaces";
            
        #endregion

        #region     INTROVIEWMODEL

        public const string INTROVIEWMODEL_INITIALISATION_BEGIN = "Begin IntroViewModel Initialisation";
            
        public const string INTROVIEWMODEL_INITIALISATION_END = "IntroViewModel Initialisation Complete";
            
        public const string INTROVIEWMODEL_END_COMMABOARD_STARTUP = NEWLINE + "COMMABOARD STARTUP PROCESSES COMPLETED";
           
        public const string INTROVIEWMODEL_INITIALISATION_ERROR = "Error occurred during Initialisation processes";
           
        #endregion

        #region     CONTROLVIEWMODEL

        public const string CONTROLVIEWMODEL_INITIALISATION_BEGIN = "Begin ControlViewModel Initialisation";
            
        public const string CONTROLVIEWMODEL_INITIALISATION_END = "ControlViewModel Initialisation Complete";
            
        public const string CONTROLVIEWMODEL_INITIALISATION_ERROR = "Error occurred during Initialisation processes";
            
        #endregion

        #region     SETTINGSVIEWMODEL

        public const string SETTINGSVIEWMODEL_INITIALISATION_BEGIN = "Begin ControlViewModel Initialisation";
            
        public const string SETTINGSVIEWMODEL_INITIALISATION_END = "ControlViewModel Initialisation Complete";
            
        public const string SETTINGSVIEWMODEL_INITIALISATION_ERROR = "Error occurred during Initialisation processes";
           
        #endregion

    }

    public static class GeneralTextLibrary
    {
        #region     USER FORM DATA

        public const string INVALID_EMAIL_RESPONSE = "Please enter a valid email";

        public const string INVALID_PASSWORD_RESPONSE = "Password should be a minimum of 8 characters";

        #endregion

        #region     DATA MODEL SENT

        public const string CHANGE_CAMERA_OLD_CAMERA_NOT_FOUND = "Camera to be relaced cannot be found";

        public const string CHANGE_CAMERA_NEW_CAMERA_NOT_FOUND = "Replacement camera cannot be found";

        public const string CAMERA_LIST_SUCCESSFULLY_REQUESTED = "List of available cameras successfully requested";

        public const string CAMERA_LIST_ERROR = "Error requesting camera list from server";

        public const string LAYOUT_LIST_NO_LAYOUTS_FOUND = "No layouts returned from the server";

        public const string LAYOUT_LIST_SUCCESSFULLY_REQUESTED = "List of available layouts successfully requested";

        public const string LAYOUT_LIST_ERROR = "Error requesting layout list from server";

        public const string WINDOW_HANDLING_TARGET_ERROR = "Error targeting client window";

        #endregion

        #region     CBCLIENT

        public const string HTTP_PUT_REQUEST_SUCCESSFUL = "HTTP PUT request successfully completed";

        public const string HTTP_PUT_REQUEST_ERROR = "Error sending HTTP PUT request";

        public const string HTTP_POST_REQUEST_SUCCESSFUL = "HTTP POST request successfully completed";

        public const string HTTP_POST_REQUEST_ERROR = "Error sending HTTP POST request";

        #endregion

        #region     CB LICENSE

        public const string COMMABOARD_LICENCE_IS_ACTIVATED = "CommaBoard license is activated";

        public const string COMMABOARD_LICENCE_IS_NOT_ACTIVATED = "CommaBoard license is NOT activated";

        public const string COMMABOARD_LICENCE_ERROR = "Error establishing if CommaBoard is licensed";

        public const string COMMABOARD_LICENCE_ACTIVATION_SUCCESSFUL = "CommaBoard License activated successfully";

        public const string COMMABOARD_LICENCE_ACTIVATION_RETRY = "Error activating CommaBoard license. Please retry";

        public const string COMMABOARD_LICENCE_ACTIVATION_ERROR = "Error occurred attempting to activate CommaBoard license. Please retry";

        #endregion

        #region     CBL HTTP CLIENT

        public const string COMMABOARD_LICENSE_USER_LIST_SUCCESSFUL = "List of CommaBoard licensed Users successfully retrieved";

        public const string COMMABOARD_LICENSE_USER_LIST_ERROR = "Error retrieving list of CommaBoard licensed Users";

        public const string COMMABOARD_LICENSE_USER_PROFILE_ERROR = "Error retrieving profile for CommaBoard licensed User";

        public const string COMMABOARD_LICENSE_USER_VALIDATION_SUCCESSFUL = "CommaBoard User successfully validated";

        public const string COMMABOARD_LICENSE_USER_VALIDATION_ERROR = "Error validating CommaBoard User";

        public const string COMMABOARD_LICENSE_USER_ADD_ERROR = "Error adding new CommaBoard User";

        public const string COMMABOARD_LICENSE_PASSWORD_TOKEN_SUCCESSFUL = "Password token obtained";

        public const string COMMABOARD_LICENSE_PASSWORD_TOKEN_ERROR = "Error obtaining password token";

        public const string COMMABOARD_LICENSE_PASSWORD_RESET_ERROR = "Error resetting User password";

        #endregion
    }
}
