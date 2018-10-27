using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam
{
    class ACGT
    {
        public static int checkno(string s, int index, int p)
        {
            int l = s.Length;
            int i = index + 1, c = 0;
            char ch;
            ch = s[index];
            while (i < l)
            {
                if (s[i] != ch)
                {
                    c++;

                }
                i = i + p;


            }

            return c;
        }
        public static int change(string s, int priority)
        {
            int c = int.MaxValue, l = s.Length;
            string r;
            for (int i = 1; i <= priority; i++)
            {
                r = s.Substring(0, i);
                Console.WriteLine(r);
                int newl = r.Length;
                int p = 0;
                for (int j = 0; j <= newl; j++)
                {
                    p = p + checkno(s, j, i);


                }
                if (p < c)
                {
                    c = p;
                }

            }
            return c;
        }

        /*
        string ns = s;
        if (p > l)
            return 0;
        int i = 1;
        int m = i + p;
        Console.Write("{0}", s[m]);
        int c = 0;

        while (i < l && m < l)
        {
            if (s[i] != s[m])
            {
                s = s.Replace(s[i], s[m]);
                c++;
            }
            i++;
            m = i + p;

        }
        */
        /*
        int len = l - 1;
        m = len - p;
        int min = 0;

        while (len > 0 && m > 0)
        {
            if (ns[len] != ns[m])
            {
                ns.Replace(ns[len], ns[m]);
                min++;
            }
            len--;
            m = len - p;

        }
        if (min > c)
            return c;
            */



        public int MinChanges(int maxPeriod, string[] acgt)
        {
            int l = acgt.Length;
            string t = null;
            for (int i = 0; i < l; i++)
            {
                t = t + acgt[i];
            }
            Console.Write(t);
            int m = change(t, maxPeriod);
            return m;
        }


        public static void Main(String[] args)
        {
            ACGT aCGT = new ACGT();
            String input = Console.ReadLine();
            do
            {
                var inputParts = input.Split('|');
                int maxPeriod = int.Parse(inputParts[0]);
                string[] acgt = inputParts[1].Split(',');
                Console.WriteLine(aCGT.MinChanges(maxPeriod, acgt));
                input = Console.ReadLine();
            } while (input != "-1");

        }

    }
}