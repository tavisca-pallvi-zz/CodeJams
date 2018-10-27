using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Anagrams
    {
        int check(string s, string s2, int[] h)
        {

            int l = s.Length;

            int j;
            int[] h2 = new int[26];
            for (int hl = 0; hl < 26; hl++)
            {
                h2[hl] = 0;
            }
            int length = s2.Length;
            if (l != length)
                return 0;

            for (j = 0; j < length; j++)
            {
                h2[s2[j] - 'a']++;

            }
            for (j = 0; j < l; j++)
            {


                if (h2[s[j] - 'a'] != h[s[j] - 'a'])
                {
                    break;
                }

            }
            if (j == l)
            {
                return 1;
            }
            return 0;

        }



        int GetMaximumSubset(string[] s)
        {
            int length = s.Length;
            int i = 0, c = 0;
            while (i < length)
            {
                if (string.IsNullOrEmpty(s[i]))
                {
                    // Console.WriteLine("hello");
                    i++;
                    continue;
                }
                c++;
                int[] h = new int[26];
                for (int hl = 0; hl < 26; hl++)
                {
                    h[hl] = 0;
                }
                int l = s[i].Length;

                for (int j = 0; j < l; j++)
                {
                    h[s[i][j] - 'a']++;
                }
                for (int ni = i + 1; ni < length; ni++)
                {
                    if (string.IsNullOrEmpty(s[ni]))
                    {
                        continue;
                    }
                    int ch = check(s[i], s[ni], h);
                    if (ch == 1)
                        s[ni] = null;
                }
                i++;
            }

            //Your code goes here
            return c;
        }
        #region
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Anagrams anagramSolver = new Anagrams();
            do
            {
                string[] words = input.Split(',');
                Console.WriteLine(anagramSolver.GetMaximumSubset(words));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
