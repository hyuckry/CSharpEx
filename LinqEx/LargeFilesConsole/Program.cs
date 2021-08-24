using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace LargeFilesConsole
{
    class Program
    {
        static Action<string> WriteLine = x => Console.WriteLine(x);
        static void Main(string[] args)
        {
            Func<int, int> f = x => x * x;
            Func<int, int, int> add = (x, y) => 
            { 
                return x + y;
            };

            Action<string> WriteLine = x => Console.WriteLine(x);

            string path = @"C:\windows";
            /*
            ShowLargeFilesWithoutLinq(path);
            WriteLine("******");
            ShowLargeFilesWithLinq(path);
            */

            /*Power of IEnumerable */
            //Employee[] developers = new Employee[]
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{Id=1,Name="Scott"},
                new Employee{Id=2,Name="Chris"}
            };
            //List<Employee> sales = new List<Employee>
            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee{Id=3,Name="Alex"}
            };

            //foreach (var person in sales)
            //{
            //    WriteLine($"{person.Name}");
            //}

            //IEnumerator<Employee> enumerator = sales.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    WriteLine(enumerator.Current.Name);
            //}

            /*Lambda Expression*/
            foreach (var employee in developers.Where(s=>s.Name.StartsWith("S")))
            {
                WriteLine(employee.Name);
            }

            var query = from developer in developers
                        where developer.Name.Length > 5
                        orderby developer.Name
                        select developer;
            foreach (var emp in query)
            {
                WriteLine(emp.Name);
            }
        }
         

        private static void ShowLargeFilesWithLinq(string path)
        { 
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
            foreach (var item in query)
            {
                WriteLine($"{item.Name,-30} : {item.Length,20:N0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            Array.Sort(files,new FileInfoComparer());

            foreach (var item in files)
            {
                WriteLine($"{item.Name, - 30} : {item.Length, 20:N0}");
            }
        }



        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare([AllowNull] FileInfo x, [AllowNull] FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
         
    }
}
