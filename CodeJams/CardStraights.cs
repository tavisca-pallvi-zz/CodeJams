using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class CardStraights
    {
        int fun(int[] c)
        {
            int m = 0, f = 0;
            int i = 0, s = 0, count = 0;

            i = 0;
            int flag = 0;
            for (i = 0; i < c.Length - 1; i++)
            {
                flag = 0;
                if ((c[i + 1] - c[i]) == 1)
                {
                    flag = 1;
                    count++;
                    //      Console.WriteLine("count is{0} {1} {2}", c[i + 1], c[i], count);
                }

                if (m < count)
                {
                    m = count;
                    //  Console.WriteLine("count is{0}", m);
                }
                if (flag == 0)

                    count = 0;
            }



            return m + 1;
        }


        int LongestStraight(int[] d)
        {

            int l = d.Length;
            int[] c = new int[l];
            int index = 0;
            int i = 0;
            int f = 0, max = 0;
            int t = 0;
            Array.Sort(d);
            while (i < l - 1)
            {
                if (d[i] == 0)
                {
                    i++;
                    t++;
                    continue;

                }

                if (d[i] != d[i + 1])
                {
                    c[index] = d[i];
                    index++;

                }
                i++;
            }
            max = t + 1;
            c[index] = d[l - 1];
            index++;
            l = index;
            //changed the list
            if (t == 0)
            {
                max = fun(c);
                return max;
            }
            int diff;
            i = 0;



            while (i < l - 1)
            {

                int j = i + 1;
                //  Console.WriteLine(j);
                f = 1;
                while (f == 1 && j < l)
                {
                    diff = (c[j] - c[i] - 1) - (j - i - 1);
                    if (diff == t)
                    {
                        if (max < (c[j] - c[i] + 1))
                            max = (c[j] - c[i] + 1);
                        j++;

                    }
                    else if (diff <= t)
                    {
                        if (max < (c[j] - c[i] + (t - diff) + 1))
                            max = (c[j] - c[i] + (t - diff) + 1);
                        j++;
                        // Console.WriteLine(j);
                    }
                    else
                    {
                        f = 0;

                    }

                }
                i = j;
                //Console.WriteLine(i);
            }

            //   
            return max;

        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            CardStraights cardStraights = new CardStraights();
            do
            {
                int[] cards = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(cardStraights.LongestStraight(cards));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}