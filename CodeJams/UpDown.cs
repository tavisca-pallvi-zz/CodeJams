using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CodeJam
{
    class UpDown
    {
        public int LongestUpDown(int[] seq)
        {

            int l = seq.Length, count = 0;
            int i = 0;
            if (l == 1)
                return 1;
            List<int> list = new List<int>();
            while (i < l - 1)
            {
                if ((seq[i + 1] - seq[i]) == 0)
                {
                    i++;
                    continue;
                }
                list.Add(seq[i + 1] - seq[i]);

                i++;
            }
            if (list.Count == 0)
                return 1;
            int f = 0;
            if (list[0] >= 0)
                f = 1;
            else
                f = 0;
            i = 1;
            int len = list.Count();
            while (i < len)
            {
                // Console.WriteLine("list at {0}  {1}",i,list[i]);


                if (list[i] < 0)
                {
                    if (f == 1)
                    {
                        count++;

                        f = 0;
                    }

                }


                if (list[i] > 0)
                {
                    if (f == 0)
                    {
                        count++;
                        f = 1;
                    }


                }

                i++;



            }

            return count + 2;
        }



        #region Testing code Do not change
        public static void Main(String[] args)
        {
            UpDown upDown = new UpDown();
            String input = Console.ReadLine();
            try
            {
                do
                {
                    int[] sequence = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                    Console.WriteLine(upDown.LongestUpDown(sequence));
                    input = Console.ReadLine();
                } while (input != "-1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("{0} for input: {1}", ex.Message, input));
            }
        }
        #endregion
    }
}