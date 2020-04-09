using System;
using System.Collections.Generic;
using System.Text;
using WorldClock.Logic.Contracts;

namespace WorldClock.Logic.BusinessObject
{
    internal class ClockView:IClockView
    {
        private readonly int hourOffset;
        private readonly int minuteOffset;

        public ClockView(Clock clock, string city, int hourOffset, int minuteOffset)
        {
            if (clock == null) throw new ArgumentNullException(nameof(clock));
            if (Math.Abs(hourOffset) > 12) // +12 , -12
                throw new ArgumentException($"{nameof(hourOffset)} - Value is not between +12 and -12");
            if (minuteOffset != 0 && minuteOffset != 15 && minuteOffset != 30 && minuteOffset != 45)
                throw new ArgumentException($"{nameof(minuteOffset)} - Value is not 0, 15, 30 or 45");

            clock.TimerTick += Clock_TimerTick;
            this.hourOffset = hourOffset;
            this.minuteOffset = minuteOffset;
            City = city;
        }

        private void Clock_TimerTick(object sender, DateTime time)
        {
            Time = time.AddHours(hourOffset).AddMinutes(minuteOffset);
        }

        public DateTime Time { get; private set; }

        public string City { get;}

        public string TimeString => this.ToString();

        public override string ToString()
        {
            return $"{City}\n{Time.ToLongDateString()}\n{Time.ToLongTimeString()}\n";
        }
    }
}
