using System;
using System.Collections.Generic;
using System.Text;

namespace LargeFilesConsole
{
    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach (var item in sequence)
            {
                count++;                
            }
            return count;
        }
    }
}
