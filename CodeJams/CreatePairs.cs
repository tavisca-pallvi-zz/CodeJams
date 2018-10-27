using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Codejam
{
    class CreatePairs
    {

        static int count(int[] a)
        {
            int k = -1;
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] < 0 && a[i + 1] > 0)
                {
                    return i;

                }
                if (a[i] == 0)
                {
                    k = i;
                    break;
                }
            }
            return k;

        }
        static int sump(int[] a, int l)
        {
            int len = a.Length - 1;
            int k = l;
            int s = 0;
            while (len >= k)
            {
                if (a[len - 1] == 1)
                {
                    s = s + a[len - 1] + a[len];

                }
                else

                    s = s + (a[len] * a[len - 1]);
                len = len - 2;
            }
            return s;
        }
        static int sumn(int[] a, int l)
        {
            int s = 0;
            int i = 0;
            while (i <= l)
            {
                s = s + (a[i] * a[i + 1]);

                i = i + 2;
            }


            return s;
        }

        public int MaximalSum(int[] a)
        {
            int n, s = 0;
            int length = a.Length - 1;
            Array.Sort(a);
            int index = count(a);
            int len = length - index;


            if ((index % 2) != 0)
            {
                if (index == 0)
                    if (a[index] == 0)
                    {
                        n = index - 2;
                        s = s + sumn(a, n);
                    }
                    else
                    {
                        s = s + a[index];
                        s = s + sumn(a, index - 1);
                    }
            }

            else
            {
                if (a[index] == 0)
                {
                    n = index - 1;
                    s = s + sumn(a, n);
                }
                else
                {
                    n = index;
                    s = s + sumn(a, n);

                }
            }

            if ((len % 2) != 0)
            {

                s = s + a[index + 1];
                s = s + sump(a, index + 2);
            }
            else
            {

                s = s + sump(a, index + 1);
            }


            return s;
        }



        /*
            if (index % 2 == 0)
            {
                n = 1;
            }
            else
            {
                n = 0;
            }
            int len = l - index;
            if (len % 2 == 0)
            {
                p = 1;
            }
            else
            {
                p = 0;
            }
            if (p == 1 && n == 0)
            {
                s = s + sump(a,index+1);
                s = s + sumn(a, index);

            }
        */
        // int s = 0, k;
        //Your code goes here
        //   int l = a.Length - 1;

        /*
        int i = l;
        while (i > 0)
        {
            if ((i - 1) == 0 && a[i - 1] == 0)
            {
                s = s + a[i] + a[i - 1];
                break;
            }
            else if (a[i] == 0 && i == 0)
            {
                s = s + a[i];
                break;
            }
            if (a[i] > 0 && a[i - 1] > 0 && a[i] != 1 && a[i - 1] != 1)
            {
                s = s + (a[i] * a[i - 1]);
            }
            else if (a[i] > 0 && a[i - 1] > 0 && a[i] == 1 || a[i - 1] == 1)
            {
                s = s + (a[i] + a[i - 1]);
            }
            else if (a[i] > 0 && a[i - 1] < 0)
            {
                //k = a[i];
                s = s + a[i];
                i--;
                break;
            }
            else if (a[i] < 0 && a[i - 1] < 0)
                break;
            i = i - 2;
        }
        int sizeofneg = i + 1;

        if (i == 0)
        {
            s = s + a[i];
        }
        int j = 0;
        while (j < i)
        {
            if (a[j] < 0 && a[j + 1] < 0)
            {
                s = s + (a[j] * a[j + 1]);
            }
            j = j + 2;
            if (j == i)
                s = s + a[j];
        }
        */



        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            CreatePairs createPairs = new CreatePairs();
            do
            {
                int[] data = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(createPairs.MaximalSum(data));
                input = Console.ReadLine();
            } while (input != "*");
        }
    }
}
