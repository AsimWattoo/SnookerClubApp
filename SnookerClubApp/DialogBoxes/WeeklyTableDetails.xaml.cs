using SnookerClubApp.Core.View_Model.Dialog;

using System.Windows;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for WeeklyTableDetails.xaml
    /// </summary>
    public partial class WeeklyTableDetails : Window
    {
        #region Constructor

        /// <summary>
        /// Default non-parameterized constructor
        /// </summary>
        public WeeklyTableDetails()
        {
            InitializeComponent();
            this.DataContext = new WeeklyTableDetailsViewModel(CloseWindow);
        }

        /// <summary>
        /// Default parameterized constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public WeeklyTableDetails(WeeklyTableDetailsViewModel viewModel)
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
