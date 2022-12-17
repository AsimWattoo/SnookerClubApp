using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.Enum;
using SnookerClubApp.Core.IoCContainer;
using SnookerClubApp.Core.Managers;
using SnookerClubApp.Core.View_Model;
using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.DialogBoxes;

using System.Windows;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Private Members

        /// <summary>
        /// The name of the file path
        /// </summary>
        private const string FILE_PATH = "appdata.json";

        #endregion

        #region Overriden Methods

        /// <summary>
        /// Calls on application startup
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IoC.RegisterStatic<ApplicationViewModel>();
            IoC.RegisterStatic<DataManager>();
            ApplicationData data = IoC.Get<DataManager>().LoadData<ApplicationData>(FILE_PATH);
            if (data == null)
                data = new ApplicationData();
            IoC.RegisterStatic<ApplicationData>(data);
            TimeManager timeManager = new TimeManager();
            timeManager.Start();

            data.Tables.ForEach(t =>
            {
                if (t.Status == TableStatus.Occuppied)
                    timeManager.AddTable(t, t.RemainingTime);
            });

            IoC.RegisterStatic<TimeManager>(timeManager);
            IoC.RegisterStatic<IDialogBoxManager>(new DialogBoxManager());
            IoC.RegisterStatic<RuntimeStorage>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ApplicationData data = IoC.Get<ApplicationData>();
            IoC.Get<DataManager>().SaveData(FILE_PATH, data);
            base.OnExit(e);
        }

        #endregion
    }
}
