using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SpeedBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==Array.Length를 직접 사용 vs Param에 넣어서 사용 => Parma이 빠름");
            ArrayLengthSpeed();
            Console.WriteLine("==Split처리 : char vs char[] => char[] 빠름.");
            StringSplitSpeed();
            Console.WriteLine("==Sting Add처리 : Interpolation vs Format vs Concat vs StringBuild => StringBuild 빠름.");
            StringAddSpeed();
            Console.WriteLine("==AnyVsCount처리 : Any vs Count => Count 빠름.");
            AnyVsCountSpeed();
            Console.WriteLine("==Count()VsCount처리 : Count() vs Count => Count 빠름.");
            Count__Count();

            Console.ReadLine();
        }

        private static void Count__Count()
        {
            List<string> strs = new List<string>() { "Akshay", "Patel", "Panth", "Patel" };

            Stopwatch watch = new Stopwatch();
            watch.Start();
            int count = strs.Count();

            Console.WriteLine("Count()-{0}", watch.Elapsed);
            watch.Restart();
            int count1 = strs.Count;

            Console.WriteLine("Count - {0}", watch.Elapsed);
        }

        private static void AnyVsCountSpeed()
        {
            Stopwatch watch = new Stopwatch();

            List<string> strs = new List<string>() { "Akshay", "Patel", "Panth", "Patel" };
            watch.Start();
            if (strs.Count() > 0)
            { }

            Console.WriteLine("List.Count()-{0}", watch.Elapsed);

            watch.Restart();
            if (strs.Any())
            { }

            Console.WriteLine("List.Any() - {0}", watch.Elapsed);
        }

        private static void StringAddSpeed()
        {
            string str = "Akshay";
            string str1 = " Patel";
            string result = string.Empty;
            Stopwatch s1 = new Stopwatch();
            s1.Start();

            result = $"{str} {str1} is an author.";

            Console.WriteLine("String Interpolation " + s1.ElapsedTicks.ToString());

            s1.Restart();
            result = string.Format("{0},{1} is an author.", str, str1);
            Console.WriteLine("String.Format " + s1.ElapsedTicks.ToString());

            s1.Restart();
            result = string.Concat(str, str1, " is an auther");
            Console.WriteLine("String.Concat " + s1.ElapsedTicks.ToString());

            s1.Restart();
            StringBuilder sb = new StringBuilder();
            sb.Append(str);
            sb.Append(str1);
            sb.Append(" is an auther");
            result = sb.ToString();
            Console.WriteLine("String Builder " + s1.ElapsedTicks.ToString());
             
        }

        private static void StringSplitSpeed()
        {
            string str = "Akshay|Patel";

            Stopwatch s1 = new Stopwatch();
            s1.Start();
            string[] temp1 = str.Split('|');
            Console.WriteLine("char split-{0}", s1.ElapsedTicks.ToString());

            Stopwatch s2 = new Stopwatch();
            s2.Start();
            string[] temp = str.Split(new char[] { '|' });
            Console.WriteLine("char[] split-{0}", s2.ElapsedTicks.ToString());             
        }

        public static void ArrayLengthSpeed()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            string[] names = { "Akshay", "Patel", "Panth" };

            for (int i = 0; i < names.Length; i++)
            {
            }

            Console.WriteLine("Name.Length Direct-{0}", watch.Elapsed);


            watch.Restart();
            string[] names1 = { "Akshay", "Patel", "Panth" };
            int k = names1.Length;
            for (int j = 0; j < k; j++)
            {
            }
            Console.WriteLine("Name.Length Parameter-{0}", watch.Elapsed);

        }


    }
}
