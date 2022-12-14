using SnookerClubApp.Core.View_Model.Base;

using System;
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

        #endregion

        #region Commands

        /// <summary>
        /// The command to close the dialog box
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Private Members

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
        }

        #endregion
    }
}
