using SnookerClubApp.Core.View_Model.Dialog;

using System.Windows;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for WeeklyTableDetails.xaml
    /// </summary>
    public partial class PopupBox : Window
    {
        #region Constructor

        /// <summary>
        /// Default non-parameterized constructor
        /// </summary>
        public PopupBox()
        {
            InitializeComponent();
			PopupDialogBoxViewModel model = new PopupDialogBoxViewModel();
            model.SetCloseMethod(CloseWindow);
            this.DataContext = model;
        }

        /// <summary>
        /// Default parameterized constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public PopupBox(PopupDialogBoxViewModel viewModel)
        {
            InitializeComponent();
            viewModel.SetCloseMethod(CloseWindow);
            this.DataContext = viewModel;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Closes the windows
        /// </summary>
        private void CloseWindow()
        {
            this.Close();
        }

        #endregion
    }
}
