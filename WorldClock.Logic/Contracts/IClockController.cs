using System;
using System.Collections.Generic;
using System.Text;

namespace WorldClock.Logic.Contracts
{
    public interface IClockController:IDisposable
    {
        IClockView CreateClockView(string city, int hourOffset = 0,int minuteOffset = 0);
    }
}
