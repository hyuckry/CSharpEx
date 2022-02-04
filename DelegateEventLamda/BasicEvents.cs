using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventLamda
{
    delegate void DelegateEventHandler(string value);
    class EventPublisher
    {
        private string theVal;
        public event DelegateEventHandler valueChanged;
        public string Val
        {
            set
            {
                this.theVal = value;
                this.valueChanged(theVal);
            }
        }
    }
     
    internal class BasicEvents
    {
        public static void MainFunc()
        {
            EventPublisher eventPublisher = new EventPublisher();
            //eventPublisher.valueChanged += obj_valueChanged;
            eventPublisher.valueChanged += delegate (string value)
            {
                Console.WriteLine($"The value chaged to {value}");
            };


            string str;
            do
            {
                Console.WriteLine("Enter a value: ");
                str= Console.ReadLine();    

                eventPublisher.Val = str;

            } while (!str.Equals("exit"));
        }

        private static void obj_valueChanged(string value)
        {
            Console.WriteLine($"The value chaged to {value}");
        }
    }
}
