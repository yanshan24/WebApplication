using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFrameworkDemo
{
    class Indexer
    {
        private string[] indexList = new string[size];
        static public int size = 10;
        public Indexer()
        {
            for (int i = 0; i < size; i++)
            {
                indexList[i] = "N.A.";
            }
        }
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < size)
                {
                    return indexList[index];
                }
                else
                {
                    return "";
                }
            }

            set
            {
                if (index >= 0 && index < size)
                {
                    indexList[index] = value;
                }
            }
        }

        // 重载索引器
        public int this[string name]
        {
            get
            {
                int index = 0;
                while (index < size)
                {
                    if (indexList[index] == name)
                    {
                        return index;
                    }
                    index++;
                }
                return index;
            }
        }
        
    }
}
