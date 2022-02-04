using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new dbnumnaEntities())
            {
                var ipo = ctx.IPOSchedule.ToList();
                foreach (var item in ipo)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
        }
    }
}
