using SnookerClubApp.Core.Enum;
using SnookerClubApp.Core.IoCContainer;
using SnookerClubApp.Core.View_Model.Base;

using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private int Number = 6;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HomeViewModel()
        {
            ApplicationData data = IoC.Get<ApplicationData>();
            Tables = new ObservableCollection<Table>(new List<Table>()
            {
                new Table(){ Number = 1, CurrentDayRate= 4.5, Status=TableStatus.Occuppied },
                new Table(){ Number = 2, CurrentDayRate = 2.4 },
                new Table(){ Number = 3, CurrentDayRate = 29.23 },
                new Table(){ Number = 4, CurrentDayRate = 23.0 },
                new Table(){ Number = 5, CurrentDayRate = 23 },
            });
            AddCommand = new RelayCommand(() => 
            {
                Tables.Add(new Table()
                {
                    Number = Number++,
                    CurrentDayRate = 43,
                });
            });
        }

        #endregion

    }
}
