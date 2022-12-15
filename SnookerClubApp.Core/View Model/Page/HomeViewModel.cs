using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.Enum;
using SnookerClubApp.Core.IoCContainer;
using SnookerClubApp.Core.View_Model.Base;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Input;

namespace SnookerClubApp.Core.View_Model.Page
{
    public class HomeViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The tables to be displayed on the screen
        /// </summary>
        public ObservableCollection<Table> Tables { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to add new table
        /// </summary>
        public ICommand AddCommand { get; set; }

        #endregion

        #region Private Members

        private int Number = 1;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HomeViewModel()
        {
            ApplicationData data = IoC.Get<ApplicationData>();
            Tables = new ObservableCollection<Table>(data.Tables);
            if (data.Tables.Count > 0)
                Number = data.Tables.OrderByDescending(f => f.Number).First().Number + 1;
            AddCommand = new RelayCommand(() => 
            {
                Table t = new Table()
                {
                    Number = Number++,
                    CurrentDayRate = 0,
                    WeeklyRates = new List<double>() { 0, 0, 0, 0, 0, 0, 0,}
                };
                data.Tables.Add(t);
                Tables.Add(t);
            });
        }

        #endregion
    }
}
