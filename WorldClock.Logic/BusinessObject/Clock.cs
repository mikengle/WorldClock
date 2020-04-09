using System;
using System.Timers;

namespace WorldClock.Logic.BusinessObject
{
    internal class Clock
    {
        private static Clock instance = null;
        private Timer timer;

        internal event EventHandler<DateTime> TimerTick;

        private Clock()
        {
            timer = new Timer();
            timer.Interval = 250; // Interval
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimerTick?.Invoke(this, DateTime.UtcNow); // UTC time
        }

        internal static Clock GetInstance()
        {
            if (instance == null)
            {
                instance = new Clock();
            }
            return instance;
        }
    }
}
