using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using EventApp;

namespace ConsoleAppFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("started...");
            Client c1 = new Client("c1");
            Client c2 = new Client("c2");

            Dog d = new Dog("Pecky");
            d.OnNameChanged += c1.Subscribe;
            d.OnNameChanged += c2.Subscribe;
            d.SetName("Becky");
            Console.ReadKey();
        }
    }
}
