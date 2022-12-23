using SnookerClubApp.Core.Enum;
using SnookerClubApp.Core.IoCContainer;
using SnookerClubApp.Core.Managers.Interface;
using SnookerClubApp.Core.View_Model;
using SnookerClubApp.Core.View_Model.Base;

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

        /// <summary>
        /// The event which will be fired when the table overtimes
        /// </summary>
        public event Action<int> TableOvertime;

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
        /// The data of all the tables added in the TimeManager
        /// </summary>
        private Dictionary<int, TimeSpan> TablesData { get; set; } = new Dictionary<int, TimeSpan>();

        /// <summary>
        /// Indicates that the table has been overtimed
        /// </summary>
        private Dictionary<int, bool> Overtimed { get; set; } = new Dictionary<int, bool>();

        /// <summary>
        /// Indictaes the current state of the timer
        /// </summary>
        private bool _isRunning = false;

        /// <summary>
        /// The timespan to decrease the timer
        /// </summary>
        private TimeSpan _ts = TimeSpan.FromSeconds(1);

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
        /// <param name="tableNumber">The number of the table for which this is being setup</param>
        /// <param name="time">The time for thish it should run</param>
        public void AddTable(int tableNumber, TimeSpan time)
        {
            Tables.Add(tableNumber, time);
            TablesData.Add(tableNumber, new TimeSpan(time.Ticks));
            Overtimed.Add(tableNumber, false);
        }

        /// <summary>
        /// Removes the table from the timer
        /// </summary>
        /// <param name="t"></param>
        public void RemoveTable(int t)
        {
            Tables.Remove(t);
            TablesData.Remove(t);
            Overtimed.Remove(t);
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
            foreach (int t in Tables.Keys)
            {
                Tables[t] = Tables[t].Subtract(_ts);
                //Checking if the timer is not running infinitely for a table
                //If not then check for overtime
                if (TablesData[t] != TimeSpan.Zero)
                {
                    if (Tables[t] <= TimeSpan.Zero && !Overtimed[t])
                    {
                        Overtimed[t] = true;
                        IoC.Get<IAudioManager>().Play(AudioSound.Overtime);
                        TableOvertime?.Invoke(t);
                    }
                }
                //Firing the event to let the listeners know
                Tick?.Invoke(t, Tables[t]);
            }
        }

        #endregion

    }
}
