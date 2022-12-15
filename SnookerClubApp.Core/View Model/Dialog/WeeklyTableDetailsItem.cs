using SnookerClubApp.Core.View_Model.Base;

namespace SnookerClubApp.Core.View_Model.Dialog
{
    public class WeeklyTableDetailsItem : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The current value for the model
        /// </summary>
        public double Value { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WeeklyTableDetailsItem(double value)
        {
            Value = value;
        }

        #endregion

    }
}
