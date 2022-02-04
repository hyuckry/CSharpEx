using System;

namespace DelegateEventLamda
{
    public class BasicDelegate
    {
        public delegate string MyDelegate(int a, int b);

        static string func1(int a, int b)
        {
            return (a * b).ToString();
        }
        static string func2(int a, int b)
        {
            return (a + b).ToString();
        }
        class MyClass
        {
            public string  instanceMethod(int a, int b)
            {
                return ((a+b)*a).ToString();
            }
        }
        public static void MainFunc()
        {
            MyDelegate f = func1;
            Console.WriteLine("func1 : " + f(10,20));
            f=func2;
            Console.WriteLine("func2 : " + f(10, 20));
            f = new MyClass().instanceMethod;
            Console.WriteLine("instanceMethod : " + f(10, 20));
            //TODO: Implement an anonymous delegate
            f = delegate (int a, int b)
            {
                return (a * b).ToString();
            };

            Console.WriteLine("anonymous delegate : " + f(10, 20));

        }
    }
}
