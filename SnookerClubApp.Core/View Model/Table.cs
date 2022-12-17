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
        public double CurrentDayRate
        {
            get 
            {
                string day = DateTime.Now.ToString("dddd");
                return WeeklyRates[day];
            }
        }

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
        public Dictionary<string, double> WeeklyRates { get; set; } = new Dictionary<string, double>()
        {
            ["Monday"] = 0,
            ["Tuesday"] = 0,
            ["Wednesday"] = 0,
            ["Thursday"] = 0,
            ["Friday"] = 0,
            ["Saturday"] = 0,
            ["Sunday"] = 0,
        };

        #endregion
    }
}
