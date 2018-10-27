using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CodeJam
{
    class ACGT
    {
        int Count(int maxPeriod, string s)
        {
            int len = s.Length;
            int index = 0;
            int sum = 0;
            int jump = maxPeriod + 1;
            for (int index2 = 0; index2 <= maxPeriod; index2++)
            {
                index = index2;

                int max = 0;
                int[] h = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    h[i] = 0;
                }
                int count = 0;
                //  Console.WriteLine(s[index]);
                while (index < len)
                {
                    if (s[index] == 'A')
                    {
                        h[0]++;

                        if (max < h[0])
                            max = h[0];
                    }
                    else if (s[index] == 'C')
                    {
                        h[1]++;

                        if (max < h[1])
                            max = h[1];
                    }
                    else if (s[index] == 'G')
                    {
                        h[2]++;

                        if (max < h[2])
                            max = h[2];
                    }
                    else if (s[index] == 'T')
                    {
                        h[3]++;

                        if (max < h[3])
                            max = h[3];
                    }


                    count++;
                    index = index + jump;
                }
                // Console.WriteLine("max is{0} ",max);

                //  Console.WriteLine("count is{0} ",count);


                sum = sum + count - max;
                //  Console.WriteLine("sum is{0} ", sum);

            }
            return sum;
        }
        int MinChanges(int maxPeriod, string[] acgt)
        {
            int len = acgt.Length;

            int min = int.MaxValue;
            string s = "";
            for (int index = 0; index < len; index++)
            {
                s = s + acgt[index];

            }

            /// Console.WriteLine(s);
            for (int index = 0; index < maxPeriod; index++)
            {
                int res = Count(index, s);
                //Console.WriteLine("period is {0}",res);
                if (min > res)
                    min = res;


            }


            //Your code goes here
            return min;
        }

        #region Testing code Do not change
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
        #endregion
    }
}