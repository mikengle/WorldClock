using System;
using System.Collections.Generic;
using System.Text;
using WorldClock.Logic.Contracts;

namespace WorldClock.Logic
{
    public class Factory
    {
        public static IClockController Create()
        {
            return new ClockController();
        }
    }
}
