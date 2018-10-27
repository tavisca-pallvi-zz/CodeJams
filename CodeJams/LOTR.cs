using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace CodeJam
{
    class LOTR
    {
        int GetMinimum(int[] rep)
        {
            Array.Sort(rep);
            int j, c = 0, v = 0, i = 0;
            while (i < rep.Length)
            {
                v = rep[i];
                c = c + v + 1;
                for (j = i + 1; j <= (i + v); j++)
                {
                    if (j < rep.Length)
                    {
                        if (rep[j] != v)
                            break;
                    }

                }
                i = j;

            }
            //Your code goes here
            return c;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            LOTR lotr = new LOTR();
            String input = Console.ReadLine();
            do
            {
                int[] replies = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(lotr.GetMinimum(replies));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}