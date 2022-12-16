using SnookerClubApp.Core.View_Model.Base;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SnookerClubApp.Core.View_Model.Dialog
{
    public class WeeklyTableDetailsViewModel : BaseViewModel
    {

        #region Public Properties

        public string Title { get; set; } = "Weekly Details";

        /// <summary>
        /// The height of the caption
        /// </summary>
        public int CaptionHeight { get; set; } = 60;

        /// <summary>
        /// The list of weekly details items
        /// </summary>
        public List<WeeklyTableDetailsItem> Items { get; set; } = new List<WeeklyTableDetailsItem>();

        #endregion

        #region Commands

        /// <summary>
        /// The command to close the dialog box
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Command to save the data to the table
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Private Members

        /// <summary>
        /// The table whose weekly details are being shown
        /// </summary>
        private Table _table { get; set; } = new Table();

        /// <summary>
        /// The action to call when the close button is clicked
        /// </summary>
        private Action _closeAction;

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the close method
        /// </summary>
        /// <param name="closeAction"></param>
        public void SetCloseMethod(Action closeAction)
        {
            _closeAction = closeAction;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WeeklyTableDetailsViewModel(Action closeAction)
        {
            _closeAction = closeAction;
            Initialize();
        }

        /// <summary>
        /// Default non-parameterized constructor
        /// </summary>
        public WeeklyTableDetailsViewModel()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor initializing the viewmodel with data
        /// </summary>
        /// <param name="t"></param>
        public WeeklyTableDetailsViewModel(Table t)
        {
            _table = t;
            Items = t.WeeklyRates.Select(f => new WeeklyTableDetailsItem(f.Value)).ToList();
            Initialize();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes common method
        /// </summary>
        private void Initialize()
        {
            CloseCommand = new RelayCommand(() =>
            {
                _closeAction.Invoke();
            });
            SaveCommand = new RelayCommand(() =>
            {
                List<string> days = _table.WeeklyRates.Keys.ToList();
                for (int i = 0; i < Items.Count; i++)
                {
                    _table.WeeklyRates[days[i]] = Items[i].Value;
                }
                _closeAction.Invoke();
            });
        }

        #endregion
    }
}
