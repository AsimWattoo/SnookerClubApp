using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.Enum;
using SnookerClubApp.Core.IoCContainer;
using SnookerClubApp.Core.Managers;
using SnookerClubApp.Core.Managers.Interface;
using SnookerClubApp.Core.View_Model;
using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.DialogBoxes;
using SnookerClubApp.Managers;

using System.Collections.Generic;
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
            timeManager.TableOvertime += TimeManager_TableOvertime;
            timeManager.Start();

            data.Tables.ForEach(t =>
            {
                if (t.Status == TableStatus.Occuppied)
                    timeManager.AddTable(t.Number, t.RemainingTime);
            });

            IoC.RegisterStatic<TimeManager>(timeManager);
            IoC.RegisterStatic<IDialogBoxManager>(new DialogBoxManager());
            IoC.RegisterStatic<RuntimeStorage>();
            AudioManager audioManager = new AudioManager(new Dictionary<AudioSound, string>()
            {
                [AudioSound.Overtime] = "Data/Audios/service-bell.wav"
            });
            IoC.RegisterStatic<IAudioManager>(audioManager);
        }

        /// <summary>
        /// Fires when the table is overtimed
        /// </summary>
        /// <param name="tableNumber">The table which has overtimed</param>
        private void TimeManager_TableOvertime(int tableNumber)
        {
            this.Dispatcher.Invoke(() => IoC.Get<IDialogBoxManager>().ShowPopup($"Table {tableNumber} has reached the time limit", asDialog: false));
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
