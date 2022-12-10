﻿using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.View_Model.Base;

using SnookerClubApp.Pages;

namespace SnookerClubApp.Converters
{
    public static class ApplicationPageHelpers
    {

        /// <summary>
        /// Converts an <see cref="ApplicationPages"/> to <see cref="BasePage"/>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPages page, BaseViewModel viewModel = null)
        {
            switch (page)
            {
                case ApplicationPages.Home:
                    return new Home();
                default:
                    return new DefaultPage();
            }
        }


        /// <summary>
        /// Converts a <see cref="BasePage"/> to <see cref="ApplicationPages"/>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPages ToApplicationPage(this BasePage page)
        {
            if(page is Home h)
            {
                return ApplicationPages.Home;
            }
            return ApplicationPages.None;
        }

    }
}
