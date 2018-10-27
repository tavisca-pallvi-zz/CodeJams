using System;

namespace CodeJam
{
    class BinaryPolynomial
    {
        int CountRoots(int[] a)
        {
            int valid;
            int l = a.Length - 1;
            int c = 0, s = 0, zero = 0, one = 1;
            for (int i = 0; i < l; i++)
            {
                s = s + (a[i] * 1);
            }
            if ((s % 2) == 0)
                c++;
            if (a[0] == 0)
                c++;

            //if(a[l-1])




            return c;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            BinaryPolynomial binaryPolynomial = new BinaryPolynomial();
            String input = Console.ReadLine();
            do
            {
                int[] a = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(binaryPolynomial.CountRoots(a));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}