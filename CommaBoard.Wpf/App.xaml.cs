
using System;
using CommaBoard.Store.Static;
using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;

namespace CommaBoard.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : MvxApplication
    {

        public App() : base()
        {
            //  One possible source of Unhandled Exceptions
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;

            //  Another possible source
            AppDomain.CurrentDomain.UnhandledException +=
        new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            this.RegisterSetupType<MvxWpfSetup<Core.App>>();
        }

        /// <summary>
        /// Catch any unhandled fatal errors created by the Dispatcher
        /// </summary>
        /// <param name="sender">Object sending the error</param>
        /// <param name="e">Exception args</param>
        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Log.ErrorMessage(e.Exception, "Dispatcher Unhandled Exception" );

            e.Handled = true;
        }

        /// <summary>
        /// Catch any unhandled fatal errors created by the CurrentDomain
        /// </summary>
        /// <param name="sender">Object sending the error</param>
        /// <param name="e">Exception args</param>
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.ErrorMessage(e.ExceptionObject as Exception, "CurrentDomain Unhandled Exception");

            
        }
    }
}
