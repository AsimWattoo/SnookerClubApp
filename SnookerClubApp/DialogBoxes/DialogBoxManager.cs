using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.Core.View_Model.Dialog;
using SnookerClubApp.Core.View_Model.Item;

namespace SnookerClubApp.DialogBoxes
{
    public class DialogBoxManager : IDialogBoxManager
    {
		#region Interface Methods

		/// <summary>
		/// Shows the extras form to allow the user to enter an extra item
		/// </summary>
		/// <returns>An extra item if user selects to add otherwise null</returns>
		public ExtraItem? ShowExtrasFormDialogBox()
		{
			ExtraItem? newItem = null;
			ExtrasForm form = new ExtrasForm(new ExtrasFormViewModel(item => newItem = item));
			form.ShowDialog();
			return newItem;
		}

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

		#endregion
	}
}
