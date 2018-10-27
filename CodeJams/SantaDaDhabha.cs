using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class SantaDaDhaba
    {

        int GetValue(char x)
        {
            if (char.IsDigit(x))
                return x - 48;
            else if (char.IsUpper(x))
                return x - 55;
            else
                return x - 61;


        }







        int MaxDays(string[] prices, int budget)
        {
            int l = prices.Length;
            int sum = 0;
            int typel = prices[0].Length;
            for (int day = 0; day < l; day++)
            {
                int min = int.MaxValue;
                int flag = 0, dishchosen = 0, priceweek;
                flag = 0;
                if (typel > 7)
                {
                    typel = 7;

                }
                for (int type = 0; type < (typel - 7); type++)//looping through types in particular day
                {
                    priceweek = 0;
                    int pricefirst = GetValue(prices[day][type]);//buying on same day 

                    if ((day + 7) < l)
                    {
                        priceweek = GetValue(prices[day + 7][type]);
                    }

                    if ((sum + pricefirst + priceweek) < budget)//it should be less than budget
                    {
                        if ((pricefirst + priceweek) < min)
                        {
                            min = pricefirst + priceweek;
                        }
                    }
                    else
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                    return sum;
                sum = sum + min;
                if (sum >= budget)
                    return sum;



            }
            return sum;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            SantaDaDhaba dhaba = new SantaDaDhaba();

            do
            {
                var inputParts = input.Split('|');
                string[] prices = inputParts[0].Split(',');
                Console.WriteLine(dhaba.MaxDays(prices, Int32.Parse(inputParts[1])));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}