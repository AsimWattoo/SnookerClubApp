using SnookerClubApp.Core.View_Model.Item;

using System;
using System.Collections.Generic;

namespace SnookerClubApp.Core.View_Model.Base
{
    public interface IDialogBoxManager
    {

        #region Methods

        /// <summary>
        /// Shows the weekly details dialog box
        /// </summary>
        /// <param name="viewModel">The view model for the dialog box</param>
        void ShowWeeklyDetailsDialogBox(BaseViewModel viewModel);

        /// <summary>
        /// Shows a form for extras
        /// </summary>
        /// <returns></returns>
        ExtraItem ShowExtrasFormDialogBox(ExtraItem item = null);

        /// <summary>
        /// Shows the confirmation box and returns the result of it
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool ShowConfirmationDialogBox(string subject, string message);

        /// <summary>
        /// Shows the total form with a close button
        /// </summary>
        /// <param name="t">The table for which total form is to be shown</param>
        /// <param name="extras">The extras purchased for the table</param>
        /// <param name="totalTime">The total time consumed on the table</param>
        /// <param name="allocatedTime">The total time which was allocated to the table</param>
        /// <param name="isInfinite">Tells whether the timer is running in infinite mode</param>
        void ShowTotalForm(Table t, List<ExtraItem> extras, TimeSpan totalTime, TimeSpan allocatedTime, bool isInfinite);

        #endregion

    }
}
