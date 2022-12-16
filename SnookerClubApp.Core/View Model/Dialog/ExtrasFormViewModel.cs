using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.Core.View_Model.Item;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SnookerClubApp.Core.View_Model.Dialog
{
    public class ExtrasFormViewModel : BaseViewModel
    {

        #region Public Properties

        public string Title { get; set; } = "Add Extra";

        /// <summary>
        /// The height of the caption
        /// </summary>
        public int CaptionHeight { get; set; } = 60;

        /// <summary>
        /// The new extra item which is to be added
        /// </summary>
        public ExtraItem Item { get; set; } = new ExtraItem();

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
        /// The action to call when the close button is clicked
        /// </summary>
        private Action _closeAction;

        /// <summary>
        /// A callback to be called when the item is added
        /// </summary>
        private Action<ExtraItem> onItemAdded;

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
        public ExtrasFormViewModel(Action<ExtraItem> onItemAdded)
        {
            this.onItemAdded = onItemAdded;
            Initialize();
        }

        /// <summary>
        /// Default non-parameterized constructor
        /// </summary>
        public ExtrasFormViewModel()
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
            SaveCommand = new RelayCommand(() =>
            {
                onItemAdded(Item);
                _closeAction.Invoke();
            });
        }

        #endregion
    }
}
