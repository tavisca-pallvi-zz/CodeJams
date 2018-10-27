using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class FriendScore
    {
        public int HighestScore(string[] friends)
        {
            int l = friends.Length;
            int max = 0;
            char[,] friend = new char[l, 50];

            for (int i = 0; i < friends.Length; i++)
            {
                for (int j = 0; j < friends[i].Length; j++)
                {
                    friend[i, j] = friends[i][j];
                }
            }
            List<List<int>> twofriends = new List<List<int>>();
            for (int i = 0; i < friends.Length; i++)
            {
                List<int> x = new List<int>();
                twofriends.Add(x);

            }
            for (int i = 0; i < friends.Length; i++)
            {
                for (int j = 0; j < friends[i].Length; j++)
                {
                    if (friends[i][j] == 'Y')
                    {
                        twofriends[i].Add(j);

                    }
                }
            }
            //add friends
            for (int people = 0; people < l; people++)
            {
                int c = 0;

                int f = 0;
                int len = twofriends[people].Count;
                c = c + len;
                for (int indir = 0; indir < l; indir++)
                {
                    if (indir == people)
                        continue;
                    if (twofriends[people].Contains(indir))
                    {
                        continue;
                    }
                    for (int indirfriend = 0; indirfriend < twofriends[indir].Count; indirfriend++)//iterating every friend
                    {
                        // f = 0;
                        len = twofriends[people].Count;

                        for (int p = 0; p < len; p++)
                        {
                            //if (indir == twofriends[people][p])
                            //{
                            //    f = 1;
                            //    break;

                            //}
                            if (twofriends[indir][indirfriend] == twofriends[people][p])
                            {
                                //   twofriends[indir].Remove(twofriends[people][p]);
                                c++;
                            }
                        }
                        //if (f == 1)
                        //    break;
                    }
                }
                if (max < c)
                    max = c;
            }
            return max;

        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            FriendScore friendScore = new FriendScore();
            do
            {
                string[] values = input.Split(',');
                int validationOp = friendScore.HighestScore(values);
                Console.WriteLine(validationOp);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}