.NET5
===
.net core 3.1 이후 버전으로 4.0을 건너뜀(.net framework 4.x와 혼동방지, .NET main 개발임을 강조)

C#9.0
===
1. 최상위문 - Top level code 하나만 인정
    ```
    using System;

    namespace HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
    ```
    =>
    ```
    using System;
    Console.WriteLine("Hello World!");
    ```