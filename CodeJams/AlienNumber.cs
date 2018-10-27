using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    public class AlienNumbers
    {
        public int findindex(string source, char c)
        {
            int m = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == c)
                {
                    m = i;
                    break;
                }

            }
            return m;
        }
        public int converttodecimal(int dec, int s)
        {
            int r = 0, res = 0, v = 1;
            while (dec != 0)
            {
                r = dec % 10;
                res = res + r * v;
                dec = dec / 10;
                v = v * s;
            }
            return res;


        }
        public string getTargetNumber(string alien, string source, string target)
        {
            int len = alien.Length;
            int basesl = source.Length;
            int basetl = target.Length;
            string decn = "";

            for (int i = 0; i < len; i++)
            {
                decn = decn + findindex(source, alien[i]);
            }
            int dec = Int32.Parse(decn);

            /**/
            int valresult = converttodecimal(dec, basesl);

            int r = 0, res = 0, value = 1;
            int count = 0;
            char[] final = new char[50];

            int finalsec = 0;

            while (valresult != 0)
            {
                int rem = valresult % basetl;
                finalsec = finalsec + rem * value;
                value = value * 10;
                valresult = valresult / basetl;
            }
            int c = 0;

            while (finalsec != 0)
            {
                // Console.WriteLine("cccccc");
                r = finalsec % 10;

                final[c] = target[r];
                c++;
                finalsec = finalsec / 10;
            }

            string news = "";
            for (int i = c - 1; i >= 0; i--)
            {
                //Console.WriteLine("hhhhhhhhhhhhhh");
                news = news + final[i];
            }

            return news;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            AlienNumbers alienNumbers = new AlienNumbers();
            int cse = 1;
            do
            {
                var values = input.Split(' ');
                string validationOp = alienNumbers.getTargetNumber(values[0], values[1], values[2]);
                Console.WriteLine("Case #{0}: {1}", cse++, validationOp);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}