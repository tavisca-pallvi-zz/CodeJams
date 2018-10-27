using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Codejam
{
    class NoPointSegment
    {




        public string check(int x00, int x01, int x10, int x11, int c1, int c2, int a, int b)
        {







            if (x00 == x01 && x10 == x11 && x00 != x10)//thery mi ght be on same line segment&&yaxix
            {
                return "NO";
            }

            if (x00 == x01 && x10 == x11 && x00 == x10)//thery mi ght be on same line segment&&yaxix
            {

                if (c1 == b || c2 == a)
                    return "POINT";

                if (c1 < b)
                    return "SEGMENT";
                if (b < c1)
                    return "SEGMENT";

            }

            if (x00 == x01)
            {
                if ((x00 >= x10 && x00 <= x11) || (x00 <= x10 && x00 >= x11))
                {

                    if ((a >= c1 && a <= c2) || (a <= c1 && a >= c2))
                    {
                        return "POINT";
                    }

                }
                return "NO";
            }
            /*   if (x00 == x01)
               {
                   if (x00 > x10 && x00 < x11)
                   {

                       if (a > c1 && a < c2)
                       {
                           return "POINT";
                       }

                   }
                   return "NO";
               }

               if (x10 == x01)
               {
                   if (x00 > x10 && x00 < x11)
                   {

                       if (a > c1 && a < c2)
                       {
                           return "POINT";
                       }

                   }
                   return "NO";
               }
               */
            return null;



        }






        public string Intersection(int[] seg1, int[] seg2)
        {
            int l1 = seg1.Length;
            int l2 = seg2.Length;
            string s;
            s = check(seg1[0], seg1[2], seg2[0], seg2[2], seg1[1], seg1[3], seg2[1], seg2[3]);//CHEKING  FOR COLLINEAR PARALLED; 
            if (s != null)
                return s;
            s = check(seg1[1], seg1[3], seg2[1], seg2[3], seg1[0], seg1[2], seg2[0], seg2[2]);//CHECKING
            if (s != null)
                return s;





            /*  if (seg1[0] == seg1[2]&& seg2[0] == seg2[2]&&seg1[0]==seg2[0])//thery mi ght be on same line segment&&yaxix
            {
                if (seg2[1] < seg1[3])
                    return "SEGMENT";
                if (seg1[1] < seg2[3])
                    return "SEGMENT";
                
                if (seg1[1] == seg2[3] || seg2[1] == seg1[3])
                    return "POINT";

            }
            */






            return string.Empty;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            string input = Console.ReadLine();
            NoPointSegment solver = new NoPointSegment();
            do
            {
                var segments = input.Split('|');
                var segParts = segments[0].Split(',');
                var seg1 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                segParts = segments[1].Split(',');
                var seg2 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                Console.WriteLine(solver.Intersection(seg1, seg2));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}