﻿using System;
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
            if (args.Length == 1)
            {
                FileCheck(args[0]);
            }
            else
            {
                Console.Error.WriteLine("Error: Insert one argument only");
            }
        }

        public static void FileCheck(string fileName)
        {
            string text;
            if (File.Exists(fileName))
            {
                text = File.ReadAllText(fileName);
                Console.WriteLine(text);
            }
            else
            {
                Console.Error.WriteLine("Error: File doesn't exist");
            }
        }
    }
}
