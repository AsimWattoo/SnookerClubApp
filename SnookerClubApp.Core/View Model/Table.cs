using SnookerClubApp.Core.Enum;

using System;
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
        /// The number of hours for timer
        /// </summary>
        public double Hours { get; set; }

        /// <summary>
        /// The number of minutes for timer
        /// </summary>
        public double Minutes { get; set; }

        /// <summary>
        /// The remaining time of the currently running Table
        /// </summary>
        public TimeSpan RemainingTime { get; set; }

        /// <summary>
        /// Indicates whether the timer has limit or not
        /// </summary>
        public bool IsFixed { get; set; } = false;

        /// <summary>
        /// The weekly rates for a table
        /// </summary>
        public List<double> WeeklyRates { get; set; } = new List<double>();

        #endregion
    }
}
