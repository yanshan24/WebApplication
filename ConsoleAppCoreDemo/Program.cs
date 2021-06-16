using System;
using System.IO;
using System.Text;
namespace ConsoleAppCoreDemo
{
    class Shape
    {
        public void setSize(int[] w)
        {
            width = w[0];
            height = w[1];
        }
        protected int width;
        protected int height;
    }

    public interface PaintCost
    {
        int getCost(int area);
    }

    class Rectangle : Shape, PaintCost
    {
        public int getArea()
        {
            return (width * height);
        }
        public int getCost(int area)
        {
            return area * 70;
        }
    }
    class RectangleTester
    {
        static void Main(string[] args)
        {
            FileStream f = new FileStream("sample.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            Rectangle Rect = new Rectangle();
            int area;
            int[] size = new int[2] { 5, 7 };
            Rect.setSize(size);
            area = Rect.getArea();
            int cost = Rect.getCost(area);

            Console.WriteLine("Computed:");
            Console.WriteLine("Total Area: {0}", area);
            Console.WriteLine("Total Cost: ${0}", cost);

            // Write to file
            string str = "Total Area: " + area.ToString() + "\nTotal Cost: $" + cost.ToString();
            // reference: https://www.c-sharpcorner.com/article/c-sharp-string-to-byte-array/#:~:text=The%20Encoding.GetString%20%28%29%20method%20converts%20an%20array%20of,need%20to%20convert%20one%20encoding%20format%20to%20another%3F
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            f.Write(bytes, 0, bytes.Length);

            // Read from file
            Console.WriteLine("Read from file:");
            // https://docs.microsoft.com/zh-cn/dotnet/api/system.io.filestream.read?view=net-5.0
            f.Read(bytes, 0, bytes.Length);
            string read = Encoding.ASCII.GetString(bytes);
            Console.Write(read);

            f.Close();
        }
    }
}
