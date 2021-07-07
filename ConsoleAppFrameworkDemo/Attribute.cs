using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFrameworkDemo
{
    class Attribute
    {
        [Conditional("CONDITION1")]
        public static void WriteMsg(string message)
        {
            Console.WriteLine(message);
        }

        [Obsolete("Use NewMethod")]
        public static void OldMethod()
        {
            Console.WriteLine("This is old");
        }
        public static void NewMethod()
        {
            Console.WriteLine("This is new");
        }
    }
}
