using System;
using System.Collections.Generic;
using WorldClock.Logic.Contracts;

namespace WorldClock.ConApp
{
    class Program
    {
        private static ConsoleColor[] colors;
        static void Main(string[] args)
        {
            using IClockController ctrl = Logic.Factory.Create();
            List<IClockView> clockViews = new List<IClockView>();
            clockViews.Add(ctrl.CreateClockView("London"));
            clockViews.Add(ctrl.CreateClockView("Wien",2));
            clockViews.Add(ctrl.CreateClockView("New York",-5));
            clockViews.Add(ctrl.CreateClockView("Isfahan",4,30));
            clockViews.Add(ctrl.CreateClockView("Vadodara",5,30));

            colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            while (true)
            {
                Header();
                int i = 1;
                foreach (var clock in clockViews)
                {
                    Console.ForegroundColor = GetNextForegroundColor(i);
                    Console.Write($"{clock.TimeString} \n");
                    i++;
                }
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private static ConsoleColor GetNextForegroundColor(int i)
        {
            return colors[i];
        }

        private static void Header()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("**************************************");
            Console.WriteLine("* {0}                         *",nameof(WorldClock));
            Console.WriteLine("* {0}               *", "von Michael Engleder");
            Console.WriteLine("**************************************");
            Console.WriteLine();
        }
    }
}
