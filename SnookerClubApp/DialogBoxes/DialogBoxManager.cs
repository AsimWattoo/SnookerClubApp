using SnookerClubApp.Core.View_Model;
using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.Core.View_Model.Dialog;
using SnookerClubApp.Core.View_Model.Item;

using System.Collections.Generic;

namespace SnookerClubApp.DialogBoxes
{
    public class DialogBoxManager : IDialogBoxManager
    {
        #region Interface Methods

		/// <summary>
		/// Shows confirmation dialog box
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
        public bool ShowConfirmationDialogBox(string subject, string message)
        {
			ConfirmationDialogBox dialogBox = new ConfirmationDialogBox(new ConfirmationDialogBoxViewModel(subject, message));
			if (dialogBox.ShowDialog() == true)
				return true;
			else
				return false;
        }

        /// <summary>
        /// Shows the extras form to allow the user to enter an extra item
        /// </summary>
        /// <returns>An extra item if user selects to add otherwise null</returns>
        public ExtraItem? ShowExtrasFormDialogBox(ExtraItem? item = null)
		{
			ExtraItem? newItem = null;
			ExtrasForm form = new ExtrasForm(new ExtrasFormViewModel(item => newItem = item, item ?? new ExtraItem()));
			form.ShowDialog();
			return newItem;
		}

        /// <summary>
        /// Shows the total form with a close button
        /// </summary>
        /// <param name="t">The table for which total form is to be shown</param>
        /// <param name="extras">The extras purchased for the table</param>
        /// <param name="totalTime">The total time consumed on the table</param>
        /// <param name="allocatedTime">The total time which was allocated to the table</param>
        public void ShowTotalForm(Table t, List<ExtraItem> extras, System.TimeSpan totalTime, System.TimeSpan allocatedTime, bool isInfinite)
        {
            TotalForm form = new TotalForm(new TotalFormViewModel(t, extras, totalTime, allocatedTime, isInfinite));
            form.ShowDialog();
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
