using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class SmallestNumber
    {
        //    public int count(int no)
        //    {
        //        int val = 0;
        //        int valform = 1;
        //        while (no != 0)
        //        {
        //            val = no & 1;
        //            if (val==1)
        //            {
        //                break;
        //            }

        //            no = no / 2;
        //            valform = valform << 1;

        //        }
        //        valform= valform << 1;
        //        //valform = valform << 1;
        //        Console.WriteLine(valform);
        //        return (no | valform);

        //}

        //    public int countzero(int no)
        //{

        //}
        /* Function to check if x is power of 2*/
        //int isPowerOfTwo(int x)
        //{
        //    int val = (x & (x - 1));
        //    return val;

        //}

        public int count1(int no)
        {
            int v = 0, c = 0;
            while (no != 0)
            {
                v = no & 1;
                if (v == 1)
                    c++;

                no = no >> 1;
            }
            return c;
        }
        public int GetSmallestNumber(int no)
        {

            //int val = isPowerOfTwo(no);
            //if (val == 0)
            //    return no + no;


            int c1 = count1(no);
            // Console.WriteLine(c1);
            int c2;
            no = no + 1;
            while (true)
            {
                c2 = count1(no);
                if (c2 == c1)
                {
                    break;
                }
                no++;

            }
            return no;

            //int value = no - 1;
            //while (no != 0)
            //{

            //}


            /* if ((no % 2) == 0)
            {
                return no;
            }
            */



            /*
            if (value % 2 == 0)
            {
                return;
            }
            else
            {

            }
            */



        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            SmallestNumber smallestNumber = new SmallestNumber();
            do
            {
                int validationOp = smallestNumber.GetSmallestNumber(int.Parse(input));
                Console.WriteLine(validationOp);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}