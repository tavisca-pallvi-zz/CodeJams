using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BrokenClock
    {
        int FewestClicks(String clockTime, String currentTime)
        {
            string[] clock = null;
            string[] current = null;
            int clockhr, clockmin;
            int currenthr, currentmin;
            int clicks = 0;
            char[] splitchar = { ':' };
            clock = clockTime.Split(splitchar);
            current = currentTime.Split(splitchar);
            clockhr = Int32.Parse(clock[0]);
            clockmin = Int32.Parse(clock[1]);
            // Console.WriteLine(clockmin);
            currenthr = Int32.Parse(current[0]);
            //Console.WriteLine(currenthr);
            currentmin = Int32.Parse(current[1]);
            //Console.WriteLine(currentmin);
            int hourdiff = (currenthr - clockhr);
            int s = 0;
            int maxh = 24;
            int maxmin = 60;
            if (hourdiff >= 0)
            {
                clicks = clicks + hourdiff;
            }
            else
            {
                hourdiff = (maxh - clockhr) + currenthr;
                clicks = clicks + hourdiff;
            }

            clockmin = clockmin + hourdiff;
            if (clockmin > 60)
            {
                clockmin = clockmin - 60;
            }
            int mindiff = (currentmin - clockmin);
            if (mindiff >= 0)
            {
                clicks = clicks + mindiff;
            }
            else
                clicks = clicks + (maxmin - clockmin) + currentmin;
            return clicks;
        }

        static void Main(string[] args)
        {
            String input = Console.ReadLine();

            BrokenClock brokenClock = new BrokenClock();
            do
            {
                string[] values = input.Split(',');
                Console.WriteLine(brokenClock.FewestClicks(values[0], values[1]));
                input = Console.ReadLine();
            } while (input != "-1");



        }

    }
}

