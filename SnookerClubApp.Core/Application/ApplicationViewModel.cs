﻿using SnookerClubApp.Core.View_Model.Base;

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

        #region Public Methods

        /// <summary>
        /// Changes the current page of the application
        /// </summary>
        /// <param name="newPage"></param>
        public void ChangePage(ApplicationPages newPage, BaseViewModel viewModel = null)
        {
            CurrentPage = newPage;
            PageViewModel = viewModel;
            PropertyValueChanged(nameof(CurrentPage));
        }

        #endregion

    }
}
