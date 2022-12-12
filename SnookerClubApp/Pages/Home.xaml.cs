using SnookerClubApp.Core.View_Model.Page;

using System.Windows.Controls;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : BasePage<HomeViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Home() : base(new HomeViewModel())
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default Constructor with variable input
        /// </summary>
        public Home(HomeViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        #endregion
    }
}
