using SnookerClubApp.Core.Enum;
using SnookerClubApp.Core.IoCContainer;
using SnookerClubApp.Core.Managers;
using SnookerClubApp.Core.View_Model.Base;

using System;
using System.Timers;
using System.Windows.Input;

namespace SnookerClubApp.Core.View_Model.Page
{
    public class TableDetailsViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// The timeSpan which the timer has
        /// </summary>
        private TimeSpan timeSpan;

        #endregion

        #region Public Properties

        /// <summary>
        /// The table provided in the table details
        /// </summary>
        public Table Table { get; set; }

        /// <summary>
        /// The text to be displayed for the timer
        /// </summary>
        public string TimerText { get; set; } = "00:00:00";

        #endregion

        #region Commands

        /// <summary>
        /// The command to start the timer
        /// </summary>
        public ICommand PlayCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TableDetailsViewModel(Table t)
        {
            Table = t;
            Initialize();
        }

        /// <summary>
        /// Default Non Parameterized Constructor
        /// </summary>
        public TableDetailsViewModel()
        {
            Table = new Table();
            Initialize();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Initializes common fields
        /// </summary>
        private void Initialize()
        {
            TimeManager timeManager = IoC.Get<TimeManager>();
            if (Table.Status == TableStatus.Occuppied)
            {
                timeManager.Tick += TableDetailsViewModel_Tick;
                TimeSpan ts = timeManager.GetTimeSpanForTable(Table.Number);
                TimerText = ts.ToString("c");
            }

            PlayCommand = new RelayCommand(() =>
            {
                if(Table.Status == TableStatus.Occuppied)
                {
                    Table.Status = TableStatus.Free;
                    timeManager.RemoveTable(Table.Number);
                    timeManager.Tick -= TableDetailsViewModel_Tick;
                }
                else
                {
                    Table.Status = TableStatus.Occuppied;
                    TimeSpan ts = TimeSpan.Parse($"{Table.Hours}:{Table.Minutes}:00");
                    timeManager.AddTable(Table, ts);
                    TimerText = ts.ToString("c");
                    timeManager.Tick += TableDetailsViewModel_Tick;
                }
                PropertyValueChanged(nameof(Table));
            });
        }

        /// <summary>
        /// Fires after each second
        /// </summary>
        /// <param name="tableNumber">The table whose value is updated</param>
        /// <param name="timeSpan">The timespan value for the table</param>
        private void TableDetailsViewModel_Tick(int tableNumber, TimeSpan timeSpan)
        {
            if(tableNumber == Table.Number)
            {
                TimerText = timeSpan.ToString("c");
                PropertyValueChanged(nameof(TimerText));
            }
        }

        #endregion

    }
}
