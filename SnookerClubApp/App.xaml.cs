using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.IoCContainer;

using System.Windows;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IoC.RegisterStatic<ApplicationViewModel>();

        }

    }
}
