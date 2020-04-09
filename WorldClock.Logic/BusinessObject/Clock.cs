using System;
using System.Collections.Generic;
using System.Text;

namespace WorldClock.Logic.BusinessObject
{
    internal class Clock
    {
        private static Clock instance=null;

        private Clock()
        {
            instance = new Clock();
        }

        public static Clock GetInstance()
        {
            return instance;
        }
    }
}
