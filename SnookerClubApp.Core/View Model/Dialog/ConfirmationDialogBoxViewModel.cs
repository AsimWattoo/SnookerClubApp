using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.Core.View_Model.Item;

using System;
using System.Windows.Input;

namespace SnookerClubApp.Core.View_Model.Dialog
{
    public class ConfirmationDialogBoxViewModel : BaseViewModel
    {

        #region Public Properties

        public string Title { get; set; } = "Add Extra";

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

        /// <summary>
        /// The action to be called when the confirm button is clicked
        /// </summary>
        private Action _saveAction;

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

        /// <summary>
        /// Sets the method for confirmation to close
        /// </summary>
        /// <param name="closeAction"></param>
        public void SetSaveMethod(Action closeAction)
        {
            _saveAction = closeAction;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConfirmationDialogBoxViewModel(string title, string message)
        {
            Title = title;
            Message = message;
            Initialize();
        }

        /// <summary>
        /// Default non-parameterized constructor
        /// </summary>
        public ConfirmationDialogBoxViewModel()
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
            ConfirmCommand = new RelayCommand(() =>
            {
                _saveAction.Invoke();
            });
        }

        #endregion
    }
}
