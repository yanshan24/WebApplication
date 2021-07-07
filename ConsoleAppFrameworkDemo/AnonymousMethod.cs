using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFrameworkDemo
{
    class AnonymousMethod
    {
        static int num = 10;
        public static void Add(int i)
        {
            num += i;
            Console.WriteLine(num);
        }
        public static void Multiply(int i)
        {
            num *= i;
            Console.WriteLine(num);
        }
    }
}
