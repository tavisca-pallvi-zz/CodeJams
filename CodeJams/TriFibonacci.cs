using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam
{
    class TriFibonacci
    {

        public int Index(int[] a, int l)
        {
            int s = 0;
            for (int i = 0; i < l; i++)
            {
                //Console.WriteLine("{0}", a[i]);
                if (a[i] == -1)
                {
                    s = i;

                    break;
                }
            }
            return s;
        }


        public int Complete(int[] a)
        {
            int l = a.Length;
            int id = Index(a, l);
            //   Console.WriteLine("{0}",id);
            int s = 0, f = 0;
            if (id < 3)
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (i != id)
                    {
                        s = s + a[i];
                    }
                }

                s = a[3] - s;



                if (s < 1)
                    return -1;
                else
                    a[id] = s;
                f = 0;
                for (int i = 3; i < l; i++)
                {
                    int t = a[i - 1] + a[i - 2] + a[i - 3];
                    if (t != a[i])
                    {
                        f = 1;
                        break;
                    }

                }
                if (f == 1)
                    return -1;
                return a[id];
            }

            f = 0;
            if (id > 2)
            {
                for (int i = 3; i < id; i++)
                {
                    int t = a[i - 1] + a[i - 2] + a[i - 3];
                    if (t != a[i])
                    {
                        f = 1;
                        break;
                    }
                }
                if (f == 1)
                {
                    return -1;
                }

                a[id] = a[id - 1] + a[id - 2] + a[id - 3];
                f = 0;
                for (int i = id; i < l; i++)
                {
                    int t = a[i - 1] + a[i - 2] + a[i - 3];
                    if (t != a[i])
                    {
                        f = 1;
                        break;
                    }
                }
            }
            if (f == 1)
                return -1;
            return a[id];


        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            TriFibonacci triFibonacci = new TriFibonacci();
            do
            {
                string[] values = input.Split(',');
                int[] numbers = Array.ConvertAll<string, int>(values, delegate (string s) { return Int32.Parse(s); });
                int result = triFibonacci.Complete(numbers);
                Console.WriteLine(result);
                input = Console.ReadLine();
            } while (input != "-1");

        }
        #endregion

    }

}