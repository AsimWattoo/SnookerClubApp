using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.IoCContainer;

using System.Windows.Controls;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TopBar()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Fires when back button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().GoBack();
        }

        #endregion
    }
}
