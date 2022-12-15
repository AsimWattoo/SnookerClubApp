using SnookerClubApp.Core.View_Model.Dialog;
using SnookerClubApp.ViewModels;

using System.Windows;

namespace SnookerClubApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }
    }
}
