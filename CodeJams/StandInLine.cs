using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class StandInLine
    {
        void swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;

        }
        int[] Reconstruct(int[] left)
        {
            int j, l = left.Length;

            int[] final = new int[l];
            int max = 0;
            for (int i = 0; i < l - 1; i++)
            {
                final[i] = 0;
            }

            for (int i = 0; i < l; i++)
            {
                int v = i + 1;
                // final[left[i]] =v;
                int c = 0;
                for (j = 0; j < l; j++)
                {
                    if (final[j] != 0)
                        continue;
                    if (c == left[i])
                    {
                        break;
                    }
                    if (final[j] == 0 || final[j] > v)
                        c++;
                }
                if (j < l)
                    final[j] = i + 1;

            }







            //Your code goes here
            return final;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            StandInLine standInLine = new StandInLine();
            do
            {
                int[] left = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(string.Join(",", Array.ConvertAll<int, string>(standInLine.Reconstruct(left), delegate (int s) { return s.ToString(); })));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}