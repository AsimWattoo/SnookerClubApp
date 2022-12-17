using SnookerClubApp.Core.View_Model;

using System;
using System.Collections.Generic;
using System.Timers;

namespace SnookerClubApp.Core.Managers
{
    /// <summary>
    /// Manages the timer for different tables
    /// </summary>
    public class TimeManager
    {

        #region Events

        /// <summary>
        /// The timer tick event
        /// </summary>
        public event Action<int, TimeSpan> Tick;

        #endregion

        #region Private Members

        /// <summary>
        /// The duration of the timer to tick
        /// </summary>
        private int Duration = 1000;

        /// <summary>
        /// The which will count the time
        /// </summary>
        private Timer timer;

        /// <summary>
        /// The tables for whom time is to be tracked
        /// </summary>
        private Dictionary<int, TimeSpan> Tables { get; set; } = new Dictionary<int, TimeSpan>();

        /// <summary>
        /// Indictaes the current state of the timer
        /// </summary>
        private bool _isRunning = false;

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns the current state of the timer
        /// </summary>
        public bool IsRunning => _isRunning;

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the duraiton of the timer
        /// </summary>
        /// <param name="duration"></param>
        public void SetDuration(int duration)
        {
            Duration = duration;
        }

        /// <summary>
        /// Adds table to the timer
        /// </summary>
        public void AddTable(Table t, TimeSpan time)
        {
            Tables.Add(t.Number, time);
        }

        /// <summary>
        /// Removes the table from the timer
        /// </summary>
        /// <param name="t"></param>
        public void RemoveTable(int t)
        {
            Tables.Remove(t);
        }

        /// <summary>
        /// Runs the timer
        /// </summary>
        public void Start()
        {
            timer = new Timer(Duration);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            _isRunning = true;
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
            timer.Stop();
        }

        /// <summary>
        /// Returns the timespan for the specified table
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public TimeSpan GetTimeSpanForTable(int t)
        {
            TimeSpan timeSpan;
            Tables.TryGetValue(t, out timeSpan);
            return timeSpan;
        }

        /// <summary>
        /// Indicates whether the timer is running
        /// </summary>
        /// <param name="table">The id of the table</param>
        /// <returns></returns>
        public bool IsTimerRunning(int table)
        {
            if (Tables.ContainsKey(table))
                return true;
            else
                return false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Fires when the timer elapses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan ts = TimeSpan.FromSeconds(1);
            foreach (int t in Tables.Keys)
            {
                Tables[t] = Tables[t].Subtract(ts);
                //Firing the event to let the listeners know
                Tick?.Invoke(t, Tables[t]);
            }
        }

        #endregion

    }
}
