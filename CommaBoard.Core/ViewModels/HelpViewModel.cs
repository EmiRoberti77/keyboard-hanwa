
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using CommaBoard.Store.Library;

namespace CommaBoard.Core.ViewModels
{
    public class HelpViewModel : MvxViewModel
    {
        #region     Private Fields

        readonly IMvxNavigationService _navigationService;

        IntroViewModel introViewModel;

        #endregion

        #region     Text And Misc Bindings

        string _viewTitle;
        public string ViewTitle
        {
            get { return _viewTitle; }

            set { SetProperty(ref _viewTitle, value); }
        }

        string _informationText;
        public string InformationText
        {
            get { return _informationText; }

            set { SetProperty(ref _informationText, value); }
        }

        #endregion

        #region     Commands

        private IMvxCommand _goBackCommand;
        public IMvxCommand GoBackCommand
        {
            get
            {
                _goBackCommand = _goBackCommand ?? new MvxCommand(() => _navigationService.Navigate(introViewModel));
                return _goBackCommand;
            }
        }

        #endregion

        #region     Constructor

        public HelpViewModel(IMvxNavigationService navigationService, IntroViewModel ivm)
        {
            _navigationService = navigationService;
            introViewModel = ivm;

            Initialise();          
        }

        #endregion

        #region     Private Methods

        void Initialise()
        {
            InitialiseViewText();
        }

        void InitialiseViewText()
        {
            ViewTitle = DisplayTextLibrary.HELP_VIEW_TITLE;
            InformationText = DisplayTextLibrary.HELP_VIEW_INFO_TEXT;
        }
        #endregion

    }
}
