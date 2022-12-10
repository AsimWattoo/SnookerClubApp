using SnookerClubApp.Core.Application;
using SnookerClubApp.Core.IoCContainer;

namespace SnookerClubApp
{
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// The application model used for the application
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        #endregion
    }
}
