using SnookerClubApp.Core.Enum;

using System.Collections.Generic;

namespace SnookerClubApp.Core.View_Model
{
    public class Table
    {
        #region Public Properties

        /// <summary>
        /// The number of the table
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The current status of the table
        /// </summary>
        public TableStatus Status { get; set; }

        /// <summary>
        /// The rate of the table
        /// </summary>
        public double CurrentDayRate { get; set; }

        /// <summary>
        /// The weekly rates for a table
        /// </summary>
        public Dictionary<string, double> WeeklyRates { get; set; } = new Dictionary<string, double>();

        #endregion
    }
}
