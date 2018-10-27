using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class BinaryCoder
    {
        public String[] Decode(string test)
        {

            int l = test.Length;
            int[] st = new int[l];
            int[] st2 = new int[l];
            st[0] = 0;
            st2[0] = 1;
            int[] arr = new int[l];
            string result1 = string.Join("", st);
            string result2 = string.Join("", st2);
            int f1 = 0, f2 = 0;
            for (int i = 0; i < test.Length - 1; i++)
            {
                arr[i] = (Int32.Parse(test[i].ToString()));
                //Console.WriteLine(arr[i]);
            }
            //Console.WriteLine("hello");
            for (int i = 1; i < test.Length; i++)
            {
                if (i == 1)
                {
                    st[i] = arr[i - 1] - st[i - 1];
                    if (st[i] < 0 || st[i] > 1)
                    {
                        f1 = 1;
                        result1 = "NONE";
                    }

                    //  Console.WriteLine(st[i]);
                    st2[i] = arr[i - 1] - st2[i - 1];
                    if (st2[i] < 0 || st2[i] > 1)
                    {
                        f2 = 1;
                        result2 = "NONE";
                    }
                    //   Console.WriteLine(st2[i]);
                }


                else
                {
                    st[i] = arr[i - 1] - st[i - 2] - st[i - 1];
                    if (st[i] < 0 || st[i] > 1)
                    {
                        f1 = 1;
                        result1 = "NONE";
                    }
                    //   st[i + 1] = arr[i] - (st[i] + st[i - 1]);

                    // Console.WriteLine(st[i]);
                    st2[i] = arr[i - 1] - st2[i - 2] - st2[i - 1];
                    if (st2[i] < 0 || st2[i] > 1)
                    {
                        f2 = 1;
                        result2 = "NONE";
                    }
                    // st[i + 1] = arr[i] - (st[i] + st[i - 1]);
                }
                //  Console.WriteLine(st2[i]);

            }
            if (f1 != 1)
                result1 = string.Join("", st);
            if (f2 != 1)
                result2 = string.Join("", st2);
            return new String[] {result1,result2
            };
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            BinaryCoder coder = new BinaryCoder();
            do
            {
                String[] validationOp = coder.Decode(input);
                Console.WriteLine("{0},{1}", validationOp[0], validationOp[1]);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}