using CommaBoard.Core.Models;
using CommaBoard.Core.ViewModels;
using CommaBoard.Comms;
using MvvmCross;
using MvvmCross.ViewModels;
using CommaBoard.Store.Interface;
using CommaBoard.Database.DataConnection;
using CommaBoard.Store.Class;
using System;
using CommaBoard.Store.Static;
using CommaBoard.Store.Library;
using CommaBoard.License.Client;
using CommaBoard.License.Class;
using System.Reflection;

namespace CommaBoard.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //  Log program startup
            Log.InfoMessage(LogTextLibrary.APP_CS_BEGIN_COMMABOARD_STARTUP);

            try
            {
                RegisterAppStart<IntroViewModel>();

                Mvx.IoCProvider.RegisterSingleton<ICBClient>(new CBClientHTTP());
                Mvx.IoCProvider.RegisterSingleton<IDataAccess>(new DataAccess());
                Mvx.IoCProvider.RegisterType<ICommaBoardButton, CommaBoardButton>();

                Mvx.IoCProvider.RegisterSingleton<IDataSentModel>(new WaveDataSentModel());

                Mvx.IoCProvider.RegisterType<ICommaBoardButtonModel, WaveCommaBoardButtonModel>();

                //  Log this
                Log.InfoMessage(LogTextLibrary.APP_CS_COMPLETE_INTERFACE_LINKING);
            }
            catch(Exception ex)
            {
                //  Log this error
                Log.ErrorMessage(ex, LogTextLibrary.APP_CS_ERROR_IN_INTERFACE_LINKING, MethodBase.GetCurrentMethod().Name);
            }
            

        }

    }
}
