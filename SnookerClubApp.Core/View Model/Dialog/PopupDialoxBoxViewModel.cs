using SnookerClubApp.Core.View_Model.Base;

using System;
using System.Windows.Input;

namespace SnookerClubApp.Core.View_Model.Dialog
{
    public class PopupDialogBoxViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The title of the window
        /// </summary>
        public string Title { get; set; } = "Message";

        /// <summary>
        /// The height of the caption
        /// </summary>
        public int CaptionHeight { get; set; } = 60;

        /// <summary>
        /// The message to be displayed for confirmation
        /// </summary>
        public string Message { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to close the dialog box
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Command to save the data to the table
        /// </summary>
        public ICommand ConfirmCommand { get; set; }

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
        public PopupDialogBoxViewModel(string message)
        {
            Message = message;
            Initialize();
        }

        /// <summary>
        /// Default non-parameterized constructor
        /// </summary>
        public PopupDialogBoxViewModel()
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
