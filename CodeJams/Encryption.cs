using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Codejam
{
    class Encryption
    {
        public string Encrypt(string test)
        {
            int[] h = new int[26];
            for (int i = 0; i < 26; i++)
            {
                h[i] = -1;

            }
            string a = "";
            a = a + "abcdefghijklmnopqrstuvwxyz";
            int c = 0;
            string s = "";
            for (int i = 0; i < test.Length; i++)
            {

                int v = h[test[i] - 'a'];
                if (v == -1)
                {
                    h[test[i] - 'a'] = a[c];
                    s = s + a[c];
                    c++;
                }
                else
                {
                    s = s + a[v];

                }
            }

            return s;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Encryption encryption = new Encryption();
            do
            {
                Thread th = new Thread(() =>
                {
                    try
                    {

                        string validationOp = encryption.Encrypt(input);
                        Console.WriteLine(validationOp);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception Occured" + ex.ToString());
                    }
                });
                th.Start();
                if (th.Join(1000) == false)
                {
                    Console.WriteLine("Timeout occured");
                    th.Abort();
                    return;
                }
                input = Console.ReadLine();

            } while (input != "-1");
        }

        #endregion
    }
}