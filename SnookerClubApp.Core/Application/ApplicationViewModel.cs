using SnookerClubApp.Core.View_Model.Base;

using System.Collections.Generic;

namespace SnookerClubApp.Core.Application
{
    public class ApplicationViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The current application page for the application
        /// </summary>
        public ApplicationPages CurrentPage { get; set; } = ApplicationPages.Home;

        /// <summary>
        /// The view model for the page
        /// </summary>
        public BaseViewModel PageViewModel { get; set; }

        #endregion

        #region Private Members

        /// <summary>
        /// The history of pages
        /// </summary>
        private Stack<(ApplicationPages, BaseViewModel)> _history { get; set; } = new Stack<(ApplicationPages, BaseViewModel)> ();

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the current page of the application
        /// </summary>
        /// <param name="newPage"></param>
        public void ChangePage(ApplicationPages newPage, BaseViewModel viewModel = null)
        {
            _history.Push((CurrentPage, PageViewModel));
            CurrentPage = newPage;
            PageViewModel = viewModel;
            PropertyValueChanged(nameof(CurrentPage));
        }

        /// <summary>
        /// Navigates back to the previous page
        /// </summary>
        public void GoBack()
        {
            if(_history.Count == 0) 
            {
                return;
            }

            (ApplicationPages page, BaseViewModel viewModel) = _history.Pop();
            CurrentPage = page;
            PageViewModel = viewModel;
            PropertyValueChanged(nameof(CurrentPage));
        }

        #endregion

    }
}
