using SnookerClubApp.Core.View_Model.Dialog;

using System.Windows;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for WeeklyTableDetails.xaml
    /// </summary>
    public partial class ExtrasForm : Window
    {
        #region Constructor

        /// <summary>
        /// Default non-parameterized constructor
        /// </summary>
        public ExtrasForm()
        {
            InitializeComponent();
			ExtrasFormViewModel model = new ExtrasFormViewModel();
            model.SetCloseMethod(CloseWindow);
            this.DataContext = model;
        }

        /// <summary>
        /// Default parameterized constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public ExtrasForm(ExtrasFormViewModel viewModel)
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
