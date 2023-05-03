using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using CommaBoard.Store.Class;
using Cryptlex;
using CommaBoard.License.Class;
using CommaBoard.Store.Static;
using CommaBoard.Store.Library;

namespace CommaBoard.License.Static
{
    public static class CBLicense
    {

        #region     Private Constants

        const string PRODUCT_ID = "07ff2532-df72-485f-a1eb-dee8fbbfc9a3";

        const string PRODUCT_DATA = "RTkzRjlBODcxOUFEQ0VCMEJFN0JGRTEwNEFENEI4MDI=.86XvtdREmPuMprNXmf31tVmO27+NfOkmF2ROVtGEhehat445xIihVgrLeKIr0y1DqGgjMedn2nUq17BvYnAP8tke8F4YQsQXxOHAZCdNupIAIm5KYydnLt7rrNB4ssrIz5VYGTtPUH6+eX6swab1ImxIsLEA/GdBomsJ7bHWdNhIzvhn2LnhyYjfsL0SJ2foaioPB+d+gevmhUTt7GRDlxi0gLzInwBLqOqH2W0spUUfnL0O4xU+lzWjg4Iqj5chTUyXHqqnbsURL44lLbEfRj+s/VXpnvACYIiSnZRofwbtVp+oFMK5TWEun0ae9/BB7s5X9y4Yj7t5DaiXRvlM0Fn/S8leNUCOIk+HFZBgVCYnL6jeuajFXf1+htJbhbhafkmWVUMU0QBTDmMMG5w5HOFNhp9ckuP2N9GTjNNccrDO/b2p7ek3+FGrlmIS4VOq7ldIjOOZMh7GIYnTCP2Sq9wTDxzfzHtWopziXq0rFzzoe9zcJq0D1/2CQZmkxSYEFsx7S8cA70VrQtq3aRuoxA4lnlZDwDocnNTMGPeQNs1axfMG7wwHllHUbYf3H/JWsER6pfZp0sWfnQwjWQ+ozbbv0+vPQOqQF+pdARpBGKvJ3y/7sozJ3lxVMGP4rAnU9dxEvxFm3gvE9ECcSU04IHa40dwSMPPnMxATHv5yinHfeftl2kxnIzTcGnY+ZjnM2wuvIke4pmD37Djkz6IpmatlQb5l0HA9F2ubeae+CbdJTsPu8kzEGUIIaj/BXDUabPKA0ouT5vXEvW6RJL2mp5fAmUODET4mOQCRzHJ3dyo=";

        #endregion

        #region     Converting Cryptlex Lex class to Static

        static Lex _lexLicense = new Lex();

        public static Lex LexLicense
        {
            get
            {
                return _lexLicense;
            }
        }

        #endregion

        #region     Public Properties

        public static bool LicenseIsActivated { get; set; }

        public static string LicenseActivationStatus { get; set; }

        public static AccessToken ProfileAccessToken { get; set; }

        public static AccessToken UserAccessToken { get; set; }

        #endregion

        #region     Cryptlex License Methods

        /// <summary>
        /// Cryptlex License check
        /// </summary>
        public static void CheckLicenseActivation()
        {
            try
            {
                //  Embed the Product Data and Product Id
                LexActivator.SetProductData(PRODUCT_DATA);
                LexActivator.SetProductId(PRODUCT_ID, LexActivator.PermissionFlags.LA_USER);

                //  Lex method for testing if License is genuine
                int test = LexActivator.IsLicenseGenuine();
                if (test == LexStatusCodes.LA_OK || test == LexStatusCodes.LA_EXPIRED || test == LexStatusCodes.LA_SUSPENDED || test == LexStatusCodes.LA_GRACE_PERIOD_OVER)
                {
                    LicenseIsActivated = true;

                    LicenseActivationStatus = GeneralTextLibrary.COMMABOARD_LICENCE_IS_ACTIVATED;
                }
                else
                {
                    LicenseIsActivated = false;

                    LicenseActivationStatus = GeneralTextLibrary.COMMABOARD_LICENCE_IS_NOT_ACTIVATED;
                }
            }
            catch (LexActivatorException ex)
            {
                LicenseIsActivated = false;

                LicenseActivationStatus = $"{GeneralTextLibrary.COMMABOARD_LICENCE_ERROR} Code: " + ex.Code.ToString() + " Error message: " + ex.Message;
            }

        }

        /// <summary>
        /// Try activating the Cryptlex License key
        /// </summary>
        /// <returns></returns>
        public static string ActivateLicenseOnThismachine()
        {
            try
            {
                int status;
                LexActivator.SetLicenseKey(LexLicense.CBLLicenseKey);
                status = LexActivator.ActivateLicense();
                if (status == LexStatusCodes.LA_OK || status == LexStatusCodes.LA_EXPIRED || status == LexStatusCodes.LA_SUSPENDED)
                {
                    return GeneralTextLibrary.COMMABOARD_LICENCE_ACTIVATION_SUCCESSFUL;
                }
                else
                {
                    return GeneralTextLibrary.COMMABOARD_LICENCE_ACTIVATION_RETRY;
                }
            }
            catch (LexActivatorException ex)
            {
                //  Before returning log this exception fully
                Log.ErrorMessage(ex, GeneralTextLibrary.COMMABOARD_LICENCE_ERROR);

                return $"{GeneralTextLibrary.COMMABOARD_LICENCE_ERROR}\r\nError message: {ex.Message}";
            }
        }

        #endregion
    }

    public class Lex : MvxNotifyPropertyChanged
    {

        private string _cblLicenseKey;
        public string CBLLicenseKey
        {
            get { return _cblLicenseKey; }

            set { SetProperty(ref _cblLicenseKey, value); }
        }

        private string _cblUsername;
        public string CBLUsername
        {
            get { return _cblUsername; }

            set { SetProperty(ref _cblUsername, value); }
        }

        private string _cblPassword;
        public string CBLPassword
        {
            get { return _cblPassword; }

            set { SetProperty(ref _cblPassword, value); }
        }

        List<CBLUser> _commaBoardUsers;
        public List<CBLUser> CommaBoardUsers
        {
            get { return _commaBoardUsers; }

            set { SetProperty(ref _commaBoardUsers, value); }
        }

        CBLUser _currentUserLoggedIn;
        public CBLUser CurrentUserLoggedIn
        {
            get { return _currentUserLoggedIn; }

            set { SetProperty(ref _currentUserLoggedIn, value); }
        }

        CBLUser _newUserAdded;
        public CBLUser NewUserAdded
        {
            get { return _newUserAdded; }

            set { SetProperty(ref _newUserAdded, value); }
        }

        bool _currentUserIsAdmin;
        public bool CurrentUserIsAdmin
        {
            get { return _currentUserIsAdmin; }

            set { SetProperty(ref _currentUserIsAdmin, value); }
        }

        ErrorMessage _cblErrorMessage;
        public ErrorMessage CBLErrorMessage
        {
            get { return _cblErrorMessage; }

            set { SetProperty(ref _cblErrorMessage, value); }
        }

        PasswordToken _cblPasswordToken;
        public PasswordToken CBLPasswordToken
        {
            get { return _cblPasswordToken; }

            set { SetProperty(ref _cblPasswordToken, value); }
        }


    }
}
