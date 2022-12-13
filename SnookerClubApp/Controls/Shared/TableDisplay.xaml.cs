using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.IoCContainer;
using SnookerClubApp.Core.View_Model;
using SnookerClubApp.Core.View_Model.Page;

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

        /// <summary>
        /// Handles the mouse down event on the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Table? table =  this.DataContext as Table;
            if(table != null)
            {
                IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.TableDetails, new TableDetailsViewModel(table));
            }
        }

        #endregion

    }
}
