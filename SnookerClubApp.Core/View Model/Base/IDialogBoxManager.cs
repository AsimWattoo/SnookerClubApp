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

        #endregion

    }
}
