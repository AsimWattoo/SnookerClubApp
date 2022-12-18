using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.Core.View_Model.Item;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnookerClubApp.Core.View_Model.Dialog
{
    public class TotalFormViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The table for which table is to be displayed
        /// </summary>
        public Table Table { get; set; }

        /// <summary>
        /// The list of extras for the table
        /// </summary>
        public List<ExtraItem> Extras { get; set; }

        /// <summary>
        /// The total time for the occupation of the table
        /// </summary>
        public TimeSpan TotalTime { get; set; }

        /// <summary>
        /// The timespan allocated for the table
        /// </summary>
        public TimeSpan AllocatedTime { get; set; }

        /// <summary>
        /// The overtime taken on the table
        /// </summary>
        public TimeSpan OverTime { get; set; }

        /// <summary>
        /// The title of the window
        /// </summary>
        public string Title { get; set; } = "Total Display";

        /// <summary>
        /// The height of the caption
        /// </summary>
        public int CaptionHeight { get; set; } = 60;

        /// <summary>
        /// The total amount for the table occupation
        /// </summary>
        public double Total { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to close the form
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Private Members

        /// <summary>
        /// The action to close the window
        /// </summary>
        private Action _closeAction;

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the action to the close the window
        /// </summary>
        /// <param name="closeAction"></param>
        public void SetCloseMethod(Action closeAction)
        {
            _closeAction = closeAction;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor which initializes to default
        /// </summary>
        public TotalFormViewModel()
        {
            Initialize();
        }

        public TotalFormViewModel(Table table, List<ExtraItem> extras, TimeSpan remainingTime, TimeSpan allocatedTime, bool isInfinite)
        {
            Table = table;
            Extras = extras;
            AllocatedTime = allocatedTime;
            if (!isInfinite)
            {
                if (remainingTime < TimeSpan.Zero)
                {
                    OverTime = remainingTime.Negate();
                    TotalTime = OverTime + allocatedTime;
                }
                else
                {
                    TotalTime = allocatedTime - remainingTime;
                }
            }
            else
                TotalTime = remainingTime;
            //Calculating total cost
            Total = 0;
            extras.ForEach(f => Total += f.Price);
            //Finding total for time
            Total += Math.Round(TotalTime.TotalHours * Table.CurrentDayRate, 2);

            Initialize();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes common item of the form
        /// </summary>
        private void Initialize()
        {
            CloseCommand = new RelayCommand(() =>
            {
                //Calling the provided close action to shut down the window
                _closeAction?.Invoke();
            });
        }

        #endregion

    }
}
