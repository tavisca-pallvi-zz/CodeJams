using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Medici
    {
        public int Min(int a, int b)
        {
            if (a > b)
                return b;
            return a;
        }
        public int Winner(int[] fame, int[] fortune, int[] secrets)
        {
            int l = fame.Length;
            int min = Int32.MaxValue;
            int ind = 0, c = 0;
            for (int i = 0; i < l; i++)
            {
                //for (int cat = 0; cat < 3; cat++)
                //{
                int m1 = Min(fame[i], fortune[i]);
                int m2 = Min(min, secrets[i]);
                if (m2 < min)
                {
                    c++;
                    min = m2;
                    ind = i;
                }



            }
            if (c < 2)
                return -1;

            return ind;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Medici medici = new Medici();
            do
            {
                string[] values = input.Split('|');
                string[] fameValues = values[0].Split(',');
                int[] fame = Array.ConvertAll<string, int>(fameValues, delegate (string s) { return Int32.Parse(s); });
                string[] fortuneValues = values[1].Split(',');
                int[] fortune = Array.ConvertAll<string, int>(fortuneValues, delegate (string s) { return Int32.Parse(s); });
                string[] secretValues = values[2].Split(',');
                int[] secrets = Array.ConvertAll<string, int>(secretValues, delegate (string s) { return Int32.Parse(s); });
                int validationOp = medici.Winner(fame, fortune, secrets);
                Console.WriteLine(validationOp);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}