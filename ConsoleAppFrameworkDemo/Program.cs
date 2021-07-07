#define CONDITION1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using EventApp;
using System.Reflection;

delegate void NumberChanger(int n);
namespace ConsoleAppFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // event
            //Console.WriteLine("started...");
            //Client c1 = new Client("c1");
            //Client c2 = new Client("c2");

            //Dog d = new Dog("Pecky");
            //d.OnNameChanged += c1.Subscribe;
            //d.OnNameChanged += c2.Subscribe;
            //d.SetName("Becky");

            // attribute
            //Attribute.WriteMsg("In main");
            //Attribute.OldMethod();

            // reflection
            //Type t = typeof(ReflectionClass);
            ////MemberInfo[] memberInfos = t.GetMembers(); // public member, members of parent class
            //MemberInfo[] memberInfos = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            //foreach (MemberInfo m in memberInfos)
            //{
            //    //Console.WriteLine(m.Name);
            //    Console.WriteLine(m.Name + "; Type: " + m.GetType());
            //}

            //FieldInfo[] finfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            //ReflectionClass rc = new ReflectionClass();
            //rc.Test3 = 3;
            //foreach (FieldInfo f in finfos)
            //{
            //    f.SetValue(rc, 100);
            //    Console.WriteLine("Field Name: {0}, field type: {1}, value: {2}", f.Name, f.FieldType.ToString(), f.GetValue(rc));
            //}

            // indexer
            //Indexer indexer = new Indexer();
            //indexer[0] = "index at 0";
            //for (int i = 0; i < Indexer.size; i++)
            //{
            //    Console.WriteLine(indexer[i]);
            //}

            //Indexer indexer = new Indexer();
            //indexer[6] = "index at 6";
            //for (int i = 0; i < Indexer.size; i++)
            //{
            //    Console.WriteLine(indexer[i]);
            //}
            //Console.WriteLine(indexer["index at 6"]);

            // anonymous methods
            NumberChanger nc = delegate (int x) // 使用匿名方法创建委托实例
            {
                Console.WriteLine("Anonymous method: " + x.ToString());
            };
            nc(10); // 使用匿名方法调用委托

            nc = new NumberChanger(AnonymousMethod.Add); // 使用命名方法实例化委托
            nc(5); // 使用命名方法调用委托

            nc = new NumberChanger(AnonymousMethod.Multiply);
            nc(10);

            Console.ReadKey();
        }
    }
}
