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

            FileCheck(fileName);
        }

        public static void FileCheck(string fileName)
        {
            string text;
            if (File.Exists(fileName))
            {
                text = File.ReadAllText(fileName);
                Console.WriteLine(text);
                Console.ReadLine();
            }
            else
            {
                Console.Error.WriteLine("Error: File doesn't exist");
                Console.ReadLine();
            }
        }
    }
}
