using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.View_Model.Base;
using SnookerClubApp.Core.View_Model.Page;
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
        public static BasePage ToBasePage(this ApplicationPages page, BaseViewModel? viewModel = null)
        {
            switch (page)
            {
                case ApplicationPages.Home:
                    if (viewModel == null)
                        return new Home();
                    else
                        return new Home(viewModel as HomeViewModel ?? new HomeViewModel());
                case ApplicationPages.TableDetails:
                    return new TableDetails();
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
            if(page is Home)
            {
                return ApplicationPages.Home;
            }
            else if(page is TableDetails) 
            {
                return ApplicationPages.TableDetails;
            }
            return ApplicationPages.None;
        }

    }
}
