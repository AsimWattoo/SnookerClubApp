using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.Core.View_Model.Dialog;

namespace SnookerClubApp.DialogBoxes
{
    public class DialogBoxManager : IDialogBoxManager
    {
        /// <summary>
        /// Shows the weekly details dialog box
        /// </summary>
        /// <param name="viewModel"></param>
        public void ShowWeeklyDetailsDialogBox(BaseViewModel viewModel)
        {
            //Creating the dialog box to show
            WeeklyTableDetails details = new WeeklyTableDetails(viewModel as WeeklyTableDetailsViewModel ?? new WeeklyTableDetailsViewModel());
            //Showing the dialog box
            details.ShowDialog();
        }
    }
}
