using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Dating
    {
        int Choser(string s, int f1)
        {
            char min = 'z', min2 = 'Z';
            int c = -1;
            if (f1 == 1)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (char.IsUpper(s[i]))
                    {
                        continue;
                    }
                    else if (char.IsLower(s[i]))
                    {

                        if (s[i] <= min)
                        {

                            c = i;
                            min = s[i];


                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (char.IsUpper(s[i]))
                    {

                        //Console.WriteLine("what is v");
                        //Console.WriteLine(v);
                        if (s[i] <= min2)
                        {
                            min2 = s[i];
                            c = i;
                        }


                    }
                    else
                        continue;
                }
            }
            return c;
        }

        String Dates(String circle, int k)
        {
            int j = 0, i = 0, f1 = 0;
            char rep;
            string res = "";
            int count = 0;

            int flag = 1;
            int val = k;
            int index = 0, women = 0, men = 0;

            while (i < circle.Length)
            {
                while (index < circle.Length)//counting the no of charactrs
                {
                    if (char.IsLower(circle[index]))
                        women++;
                    else
                        men++;
                    index++;
                }
                if (men == 0 || women == 0)
                {
                    return res;
                }
                index = 0;
                count = 0;
                j = i;
                int countdot = 0;
                while (index < circle.Length)//counting the no of charactrs
                {
                    if (circle[index] != '}')
                        countdot++;
                    index++;
                }
                if (countdot <= 1)
                    return res;
                index = 0;

                int ind2 = 0;
                int check = 1;

                while (count < k)
                {

                    //   Console.WriteLine(count);


                    if (circle[j] != '}')
                    {
                        count++;

                    }
                    if (count == k)
                    {
                        // Console.WriteLine(circle);
                        break;
                    }

                    j++;
                    // Console.WriteLine(count);

                    if (j == circle.Length)
                    {
                        j = 0;
                    }






                }
                //  Console.WriteLine("value of chooser");

                ///  Console.WriteLine(j);

                res = res + circle[j];
                rep = circle[j];

                if (char.IsUpper(circle[j]))
                {
                    f1 = 1;
                    circle = circle.Replace(rep, '}');
                    int c = Choser(circle, f1);
                    //  Console.WriteLine("value of nextc");
                    //Console.WriteLine(c);
                    if (c != -1)
                    {
                        res = res + circle[c];
                        rep = circle[c];
                        circle = circle.Replace(rep, '}');


                    }
                    f1 = 0;
                }
                else
                {
                    circle = circle.Replace(rep, '}');
                    int c = Choser(circle, f1);
                    if (c != -1)
                    {
                        res = res + circle[c];
                        rep = circle[c];
                        circle = circle.Replace(rep, '}');
                    }
                }

                if (j == circle.Length - 1 || j == circle.Length)
                    i = 0;
                else
                    i = j + 1;
                //    if(circle[i]=='}')
                //    {
                //        i = i + 1;

                //}

                //Console.WriteLine("value of i");
                //Console.WriteLine(i);
                index = 0;
                men = 0;
                women = 0;
                while (index < circle.Length)//counting the no of charactrs
                {
                    if (char.IsLower(circle[index]))
                        women++;
                    else if (char.IsUpper(circle[index]))
                        men++;
                    index++;
                }
                if (men == 0 || women == 0)
                {
                    return res;
                }
                res = res + " ";


            }


            return res;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Dating dating = new Dating();

            do
            {
                string[] values = input.Split(',');
                Console.WriteLine(dating.Dates(values[0], Int32.Parse(values[1])));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}