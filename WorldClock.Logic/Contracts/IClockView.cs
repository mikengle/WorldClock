using System;
using System.Collections.Generic;
using System.Text;

namespace WorldClock.Logic.Contracts
{
    public interface IClockView
    {
        DateTime Time { get; }
        string City { get; }
        string TimeString { get; }
    }
}
