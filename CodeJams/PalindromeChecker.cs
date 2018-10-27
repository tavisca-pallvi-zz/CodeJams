using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codejam
{
    class PalindromeMaker
    {
        int checkpal(int[] h)
        {

            int odd = 0;
            for (int i = 0; i < 26; i++)
            {
                if ((h[i] % 2) != 0)
                {
                    odd++;
                }

            }
            if (odd > 1)
                return 1;
            return 0;

        }


        String Make(String baseString)
        {
            char[] arr = baseString.ToCharArray();
            int len = baseString.Length;
            int begval = 0;
            int reflen = len - 1;
            int mid = len / 2;
            string res = "";
            int val = 0;
            int index = 0;
            char[] result = new char[len];
            int[] h = new int[26];

            for (int i = 0; i < 26; i++)
            {
                h[i] = 0;
            }
            for (int i = 0; i < len; i++)
            {
                h[baseString[i] - 'A']++;
            }
            int c = checkpal(h);
            if (c == 1)
                return "";

            Array.Sort(arr);

            for (int i = 0; i < 26; i++)
            {
                //if ((h[i] % 2) == 0)
                //{
                val = h[i] / 2;

                index = i + 65;

                for (int strform = 0; strform < val; strform++)
                {

                    result[begval] = ((char)index);
                    //Console.WriteLine(result[begval]);
                    begval++;

                    if (reflen >= 0)
                    {
                        result[reflen] = ((char)index);
                        // Console.WriteLine(result[strform]);
                        reflen--;
                    }

                }
                if ((h[i] % 2) != 0)
                {
                    result[mid] = ((char)index);
                    // Console.WriteLine(result[mid]);
                }

            }
            return new string(result);


        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            PalindromeMaker palindromeMaker = new PalindromeMaker();
            do
            {
                Console.WriteLine(palindromeMaker.Make(input));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}

