using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.IoCContainer;

using System.Windows.Controls;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for TableDisplay.xaml
    /// </summary>
    public partial class TableDisplay : UserControl
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TableDisplay()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.TableDetails);
        }

        #endregion
    }
}
