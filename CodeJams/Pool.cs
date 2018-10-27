using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace CodeJam
{
    class Pool
    {
        int RackMoves(int[] tri)
        {
            int[] index = new int[] { 0, 5, 9, 3, 7, 12, 10 };
            int solid = 0, no = 7, strip = 0;
            for (int i = 0; i < index.Length; i++)
            {
                if (tri[index[i]] <= 7)
                    solid++;
                else
                {
                    strip++;
                }


            }
            if (tri[4] != 8)
            {
                solid--;
                strip--;
            }
            if (solid > strip)
            {
                return (no - solid);

            }
            return (no - strip);
            //Your code goes here
            return 0;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            Pool pool = new Pool();
            String input = Console.ReadLine();
            do
            {
                int[] triangle = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(pool.RackMoves(triangle));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}