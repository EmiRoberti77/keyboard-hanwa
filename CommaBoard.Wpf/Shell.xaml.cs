
using System;
using MvvmCross.Platforms.Wpf.Views;
using CommaBoard.Store.Static;

namespace CommaBoard.Wpf
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : MvxWindow
    {
        public Shell()
        {
            try
            {
                InitializeComponent();
                WindowState = System.Windows.WindowState.Maximized;
            }
            catch(Exception ex)
            {
                //  Log the error
                Log.ErrorMessage(ex, "Shell - InitializeComponent");
            }
            
        }
    }
}
