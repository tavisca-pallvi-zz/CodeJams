using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam
{
    public class GomokuBoardChecker
    {

        public int count(string[] board, int i, int h)
        {


            int counto = 0;
            int countx = 0;
            int flago = 0;
            int flagx = 0;
            int len = board.Length;
            int invalid = 1;
            int winx = 2, wino = 1;
            int row = 0, col = 0;
            if (h == 2)
                row = i - 1;
            if (h == 3)
                col = i - 1;


            for (int j = 0; j < len; j++)
            {
                if (h == 0)
                {
                    row = i;
                    col = j;

                }
                else if (h == 1)
                {
                    row = j;
                    col = i;
                }
                else if (h == 2)
                {
                    row++;
                    col = j;
                }
                else if (h == 3)
                {
                    col++;
                    row = j;
                }
                if (counto == 5 && len == 5)
                {
                    flago = 1;
                    //Console.WriteLine("its not invalid");
                    return 1;
                }
                if (countx == 5 && len == 5)
                {
                    flagx = 1;
                    //Console.WriteLine("its not invalid");
                    return 2;
                }
                if (flago == 1)
                {
                    if (board[row][col] == 'O')
                        invalid = 0;
                }
                if (flagx == 1)
                {
                    if (board[row][col] == 'X')
                        invalid = 0;
                }

                if (board[row][col] == 'O')
                {

                    if (flago != 1)
                        counto++;

                }
                if (board[row][col] == 'X')
                {

                    if (flagx != 1)
                        countx++;
                }
                if (board[row][col] == 'X' || board[row][col] == '.')
                    counto = 0;


                if (board[row][col] == 'O' || board[row][col] == '.')
                    countx = 0;
                //Console.WriteLine("x is {0}",countx);
                //Console.WriteLine("o is {0}", counto);
                if (counto == 5 && len == 5)
                {
                    flago = 1;
                    // Console.WriteLine("its not invalid");
                    return 1;
                }
                if (countx == 5 && len == 5)
                {
                    flagx = 1;
                    //  Console.WriteLine("its not invalid");
                    return 2;
                }
            }

            if (countx < 5 || counto < 5)
                return 0;
            //Console.WriteLine(countx);
            //Console.WriteLine(counto);
            if (countx == 5)
            {
                return winx;
            }
            if (counto == 5)
            {
                return wino;
            }


            return invalid;

        }

        String Check(String[] board)
        {
            int len = board.Length;
            int status = 0;
            int oplayer = 0, xplayer = 0, diff;
            int h = 1;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (board[i][j] == 'O')
                        oplayer++;

                    if (board[i][j] == 'X')
                        xplayer++;
                }
            }
            /*Horizontal*/
            diff = Math.Abs(oplayer - xplayer);
            if (diff > 1)
                return "INVALID";

            if (oplayer < 5 && xplayer < 5)
                return "IN PROGRESS";
            for (int j = 0; j < len; j++)
            {
                status = count(board, j, h);
                if (status == -1)
                    return "INVALID";

                if (status == 1)
                    return "O WON";
                if (status == 2)
                    return "X WON";

            }



            h = 0;
            /*Vertical*/
            oplayer = 0;
            xplayer = 0;
            for (int j = 0; j < len; j++)
            {
                status = count(board, j, h);
                if (status == -1)
                    return "INVALID";
                if (status == 1)
                    return "O WON";
                if (status == 2)
                    return "X WON";

                //    Console.WriteLine("{0} {1}", oplayer, xplayer);
            }




            /*Horizsontal Diagonal*/
            // Console.WriteLine("horizontal diagonal");
            oplayer = 0;
            xplayer = 0;
            int diag = len - 5;
            h = 2;
            for (int d = 0; d <= diag; d++)
            {
                status = count(board, d, h);
                if (status == -1)
                    return "INVALID";
                if (status == 1)
                    return "O WON";
                if (status == 2)
                    return "X WON";

            }



            /*ver Diagonal*/
            // Console.WriteLine("vertical diagonal");
            h = 3;
            for (int d = 0; d <= diag; d++)
            {
                status = count(board, d, h);
                if (status == -1)
                    return "INVALID";

                if (status == 1)
                    return "O WON";
                if (status == 2)
                    return "X WON";
            }
            return "";
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            GomokuBoardChecker gomokuBoardChecker = new GomokuBoardChecker();
            String input = Console.ReadLine();
            do
            {
                Console.WriteLine(gomokuBoardChecker.Check(input.Split(',')));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}