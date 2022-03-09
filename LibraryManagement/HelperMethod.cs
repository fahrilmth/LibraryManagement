using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod2
{
    public static class ExtMetClass
    {
        public static int IntegerExtension(this string str)
        {
            return int.Parse(str);
        }
    }

    /*class Program
    {
        static void Main(string[] args)
        {
            string str = "123456";
            int num = str.IntegerExtension();
            Console.WriteLine("The output using extension method: {0}", num);
            Console.ReadLine();
        }
    }*/
}