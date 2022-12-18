using SnookerClubApp.Core.View_Model.Dialog;

using System.Windows;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for WeeklyTableDetails.xaml
    /// </summary>
    public partial class ConfirmationDialogBox : Window
    {
        #region Constructor

        /// <summary>
        /// Default non-parameterized constructor
        /// </summary>
        public ConfirmationDialogBox()
        {
            InitializeComponent();
			ConfirmationDialogBoxViewModel model = new ConfirmationDialogBoxViewModel();
            model.SetCloseMethod(CloseWindow);
            model.SetSaveMethod(Confirm);
            this.DataContext = model;
        }

        /// <summary>
        /// Default parameterized constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public ConfirmationDialogBox(ConfirmationDialogBoxViewModel viewModel)
        {
            InitializeComponent();
            viewModel.SetCloseMethod(CloseWindow);
            viewModel.SetSaveMethod(Confirm);
            this.DataContext = viewModel;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Closes the windows
        /// </summary>
        private void CloseWindow()
        {
            DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Closes the window with dialog result of true
        /// </summary>
        private void Confirm()
        {
            DialogResult = true;
            this.Close();
        }

        #endregion
    }
}
