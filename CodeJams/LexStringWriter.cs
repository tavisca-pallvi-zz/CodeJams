using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeJam
{
    public class LexStringWriter
    {
        public int Search(List<int> t, int p)
        {
            int diff = Int32.MaxValue, v = 0;
            int valueToRemove = -1;
            int k = 0;
            for (int i = 0; i < t.Count; i++)
            {
                if (Math.Abs(p - t[i]) <= diff)
                {
                    v = t[i];
                    k = i;
                    diff = Math.Abs(p - t[i]);
                }
                // Console.WriteLine("value to be list{0}", t[i]);
            }
            if (t != null)
            {
                // Console.WriteLine("value to be removed {0}", t[k]);
                if (t.Contains(v))
                    t.Remove(v);
            }

            return v;

        }


        public int MinMoves(String s)
        {
            int l = s.Length;
            List<List<int>> data = new List<List<int>>();//
            for (int i = 0; i < 26; i++)
                data.Add(new List<int>());
            char[] ch = s.ToArray();
            Array.Sort(ch);

            for (int i = 0; i < l; i++)
            {
                data[s[i] - 'a'].Add(i);

            }
            int c = 0;
            int p = 0, prev = 0;
            for (int i = 0; i < l; i++)
            {
                if (data[ch[i] - 'a'] != null)
                    p = Search(data[ch[i] - 'a'], prev);
                // Console.WriteLine("Index value is {0}",p);

                c = c + Math.Abs(p - prev) + 1;

                prev = p;
            }

            return c;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            LexStringWriter lexStringWriter = new LexStringWriter();
            String input = Console.ReadLine();
            do
            {
                Console.WriteLine(lexStringWriter.MinMoves(input));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}