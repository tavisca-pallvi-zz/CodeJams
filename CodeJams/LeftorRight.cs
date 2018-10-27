using System;
using System.Linq;

namespace CodeJam
{
    class LeftOrRight
    {
        int MaxDistance(string s)
        {
            int l = s.Length;
            int leftm = 0, rightm = 0, max = 0;
            int currleftdis = 0;
            int currrightdis = 0;
            int maxl = 0, maxr = 0;
            for (int i = 0; i < l - 1; i++)
            {
                if (max < leftm)
                    max = leftm;

                if (max < rightm)
                    max = rightm;

                if (s[i] == 'L')
                    leftm++;

                if (s[i] == 'R')
                    rightm++;

                if (s[i] == 'L' && s[i + 1] == 'R')
                {
                    if ((leftm + currleftdis) > max)
                        max = leftm + currleftdis;
                    rightm = 0;

                    if (leftm > rightm)
                    {
                        currleftdis = leftm - rightm;
                    }
                    else if (leftm < rightm)
                    {
                        currrightdis = rightm - leftm;

                    }

                }
                else if (s[i] == 'R' && s[i + 1] == 'L')
                {

                    if ((rightm + currrightdis) > max)
                        max = rightm + currrightdis;
                    leftm = 0;
                    if (max < leftm)
                        max = leftm;

                    if (max < rightm)
                        max = rightm;
                    if (leftm > rightm)
                    {
                        currleftdis = leftm - rightm;
                    }
                    else if (leftm < rightm)
                    {
                        currrightdis = rightm - leftm;

                    }


                }

            }


            //Your code goes here
            return max;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            LeftOrRight leftOrRight = new LeftOrRight();
            String input = Console.ReadLine();
            do
            {
                Console.WriteLine(leftOrRight.MaxDistance(input));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}