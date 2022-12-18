using Microsoft.SqlServer.Server;

using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.Enum;
using SnookerClubApp.Core.IoCContainer;
using SnookerClubApp.Core.Managers;
using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.Core.View_Model.Dialog;
using SnookerClubApp.Core.View_Model.Item;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        private TimeSpan allocatedTime;

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

        /// <summary>
        /// The extra items for the table
        /// </summary>
        public ObservableCollection<ExtraItem> ExtraItems { get; set; } = new ObservableCollection<ExtraItem>();

        /// <summary>
        /// Indicates whether this is overtime
        /// </summary>
        public bool IsOverTime { get; set; }

        /// <summary>
        /// Indicates whether the timer is running infinite
        /// </summary>
        public bool IsInfinite { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to start the timer
        /// </summary>
        public ICommand PlayCommand { get; set; }

        /// <summary>
        /// The command to delete the table
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// The command to view table details
        /// </summary>
        public ICommand DetailsCommand { get; set; }

        /// <summary>
        /// The command to add an extra to the table
        /// </summary>
        public ICommand AddExtraCommand { get; set; }
        
        /// <summary>
        /// The command to delete an extra item
        /// </summary>
        public ICommand DeleteExtraItemCommand { get; set; }

        /// <summary>
        /// The command to edit and extra item
        /// </summary>
        public ICommand EditExtraItemCommand { get; set; }

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
            RuntimeStorage storage = IoC.Get<RuntimeStorage>();
            if (!storage.Extras.ContainsKey(Table.Number))
                storage.Extras.Add(Table.Number, new List<ExtraItem>());
            ExtraItems = new ObservableCollection<ExtraItem>(storage.Extras[Table.Number]);
            if (Table.Status == TableStatus.Occuppied)
            {
                timeManager.Tick += TableDetailsViewModel_Tick;
                TimeSpan ts = timeManager.GetTimeSpanForTable(Table.Number);
                if (!timeManager.IsTimerRunning(Table.Number))
                {
                    ts = Table.RemainingTime;
                    timeManager.AddTable(Table, ts);
                }
                else
                {
                    Table.RemainingTime = ts;
                }
                TimerText = ts.ToString("c");
            }
            //Command to delete the table
            DeleteCommand = new RelayCommand(() =>
            {
                bool result = IoC.Get<IDialogBoxManager>().ShowConfirmationDialogBox("Table Delete Confirmation", "Are you sure you want to delete the table?");
                if (result)
                {
                    //Stopping the timer it the timer is running
                    timeManager.RemoveTable(Table.Number);
                    //Removing the table from the tables
                    IoC.Get<ApplicationData>().Tables.Remove(Table);
                    //Removing any extras for the table
                    IoC.Get<RuntimeStorage>().Extras.Remove(Table.Number);
                    //Moving to the previous page
                    IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.Home);
                }
            });
            //Command to start and stop the timer
            PlayCommand = new RelayCommand(() =>
            {
                if(Table.Status == TableStatus.Occuppied)
                {
                    Table.Status = TableStatus.Free;
                    timeManager.RemoveTable(Table.Number);
                    timeManager.Tick -= TableDetailsViewModel_Tick;
                    //Showing the total form
                    IoC.Get<IDialogBoxManager>().ShowTotalForm(Table, storage.Extras[Table.Number], Table.RemainingTime, allocatedTime, IsInfinite);
                }
                else
                {
                    Table.Status = TableStatus.Occuppied;
                    IsInfinite = Table.Hours == 0 && Table.Minutes == 0;
                    IsOverTime = false;
                    TimeSpan ts = TimeSpan.Parse($"{Table.Hours}:{Table.Minutes}:00");
                    allocatedTime = ts;
                    timeManager.AddTable(Table, ts);
                    Table.RemainingTime = ts;
                    TimerText = ts.ToString("c");
                    timeManager.Tick += TableDetailsViewModel_Tick;
                }
                PropertyValueChanged(nameof(Table));
            });
            //Command to view table details
            DetailsCommand = new RelayCommand(() =>
            {
                //Showing the dialog box
                IoC.Get<IDialogBoxManager>().ShowWeeklyDetailsDialogBox(new WeeklyTableDetailsViewModel(Table));
                PropertyValueChanged(nameof(Table));
            });
            //Command to add extra for the table
            AddExtraCommand = new RelayCommand(() =>
            {
                ExtraItem newItem = IoC.Get<IDialogBoxManager>().ShowExtrasFormDialogBox();
                if(newItem != null)
                {
                    IoC.Get<RuntimeStorage>().Extras[Table.Number].Add(newItem);
					ExtraItems.Add(newItem);
				}
            });
            DeleteExtraItemCommand = new RelayParameterizedCommand(item =>
            {
                ExtraItem extra = item as ExtraItem;
                if(extra != null)
                {
                    storage.Extras[Table.Number].Remove(extra);
                    ExtraItems = new ObservableCollection<ExtraItem>(storage.Extras[Table.Number]);
                }
            });
            EditExtraItemCommand = new RelayParameterizedCommand(item =>
            {
                ExtraItem extra = item as ExtraItem;
                if(extra != null)
                {
                    ExtraItem copy = new ExtraItem()
                    {
                        Name = extra.Name,
                        Price = extra.Price,
                    };
                    ExtraItem newItem = IoC.Get<IDialogBoxManager>().ShowExtrasFormDialogBox(copy);
                    if(newItem != null)
                    {
                        extra.Name = newItem.Name;
                        extra.Price = newItem.Price;
                        int index = storage.Extras[Table.Number].IndexOf(extra);
                        storage.Extras[Table.Number].Remove(extra);
                        storage.Extras[Table.Number].Insert(index, extra);
                        ExtraItems = new ObservableCollection<ExtraItem>(storage.Extras[Table.Number]);
                        PropertyValueChanged(nameof(ExtraItems));
                    }
                }
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
                string text = timeSpan.ToString("c");
                if (text.StartsWith("-") && !IsInfinite)
                {
                    IsOverTime = true;
                    TimerText = text;
                }
                else
                {
                    TimerText = text.Replace("-", "");
                }
                Table.RemainingTime = timeSpan;
                PropertyValueChanged(nameof(TimerText));
            }
        }

        #endregion
    }
}
