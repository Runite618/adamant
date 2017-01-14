using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adamant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide a file to read into the text string variable");

            var fileName = Console.ReadLine();
            string text;

            if (File.Exists(fileName))
            {
                text = File.ReadAllText(fileName);
                Console.WriteLine(text);
                Console.ReadLine();
            }
        }
    }
}
