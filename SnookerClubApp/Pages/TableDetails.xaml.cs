using SnookerClubApp.Core.View_Model.Page;

using System.Windows.Controls;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for TableDetails.xaml
    /// </summary>
    public partial class TableDetails : BasePage<TableDetailsViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TableDetails() : base(new TableDetailsViewModel())
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TableDetails(TableDetailsViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        #endregion
    }
}
