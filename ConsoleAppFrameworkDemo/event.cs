using System;

namespace EventApp
{
    
    public class Dog
    {
        string name;
        public delegate void Handler(); // delegate定义
        public event Handler OnNameChanged; // 委托实例 event定义
        public Dog(string a)
        {
            name = a;
            Console.WriteLine("Dog " + name + " is created");
        }
        
        public void SetName(string NewName)
        {
            name = NewName;
            if (OnNameChanged != null)
            {
                OnNameChanged(); // call event 触发
                Console.WriteLine("Dog " + name + " is changed");
            }
        }
    }

    public class Client
    {
        string name;
        public Client(string a)
        {
            name = a;
        }
        public void Subscribe() // 注册函数
        {
            Console.WriteLine(name + " is subscribed");
        }
    } 
    
}