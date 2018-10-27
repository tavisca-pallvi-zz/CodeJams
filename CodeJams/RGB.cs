using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class RGB
    {
        int checkblue(char[,] pic, int outlen, int innerlen)
        {
            int c = 0, constCount = 0, row;
            for (int col = 0; col < outlen; col++)
            {
                constCount = 0;
                row = 0;
                while (row < innerlen)
                {
                    if (pic[row, col] == '.' || pic[row, col] == 'R')
                    {
                        if (constCount > 0)
                            c++;
                        constCount = 0;
                        row++;
                        continue;
                    }
                    else
                    {
                        row++;
                        constCount++;
                    }
                }
                if (constCount > 0)
                    c++;
            }
            return c;
        }
        int checkred(char[,] pic, int outlen, int innerlen)
        {
            int c = 0, col = 0, constCount = 0;
            for (int row = 0; row < innerlen; row++)
            {
                constCount = 0;
                col = 0;
                while (col < outlen)
                {
                    if (pic[row, col] == '.' || pic[row, col] == 'B')
                    {
                        if (constCount > 0)
                            c++;
                        constCount = 0;
                        col++;
                        continue;
                    }
                    else
                    {
                        col++;
                        constCount++;
                    }
                }
                if (constCount > 0)
                    c++;
            }
            return c;
        }


        int GetLeast(string[] picture)
        {
            int rl = picture.Length;
            int cl = picture[0].Length;
            char[,] b = new char[rl, cl];
            int len = 0, count = 0;
            for (int i = 0; i < rl; i++)
            {
                len = picture[i].Length;
                for (int j = 0; j < len; j++)
                {
                    b[i, j] = picture[i][j];
                }
            }
            count = count + checkred(b, len, rl) + checkblue(b, len, rl);
            return count;

        }








        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            RGB rgbSolver = new RGB();
            do
            {
                string[] picture = input.Split(',');
                Console.WriteLine(rgbSolver.GetLeast(picture));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
