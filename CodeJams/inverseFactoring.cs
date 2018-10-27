using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Codejam
{
    class InverseFactoring
    {

        public int lcm(int[] f, int m, int min)
        {
            int a = 0, j;
            /*  if (f.Length == 1)
                  return (f[0] * f[0]);
      */
            int i = min;
            int f1 = 0;
            while (f1 == 0)
            {

                int s = m * i;
                for (j = 0; j < f.Length; j++)
                {
                    if ((s % f[j]) != 0)
                        break;

                }

                if (j == (f.Length))
                {
                    a = s;
                    f1 = 1;
                    break;
                }
                i++;
            }




            return a;
        }
        public int GetTheNumber(int[] f)
        {
            int m = int.MinValue;
            int min = int.MaxValue;
            for (int i = 0; i < f.Length; i++)
            {
                m = Math.Max(m, f[i]);
                min = Math.Min(min, f[i]);
            }
            //    Console.WriteLine(m);



            return lcm(f, m, min);

        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            InverseFactoring inverseFactoring = new InverseFactoring();
            do
            {
                Thread th = new Thread(() =>
                {
                    try
                    {

                        string[] values = input.Split(',');
                        int[] factors = Array.ConvertAll<string, int>(values, delegate (string s) { return Int32.Parse(s); });
                        int validationOp = inverseFactoring.GetTheNumber(factors);
                        Console.WriteLine(validationOp);


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception Occured" + ex.ToString());
                    }
                });
                th.Start();
                if (th.Join(1000) == false)
                {
                    Console.WriteLine("Timeout occured");
                    th.Abort();
                    return;
                }
                input = Console.ReadLine();

            } while (input != "-1");
        }

        #endregion
    }


}