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

        public static bool GetParagraphBreak(ref int pos, string text)
        {
            var searchFor = Environment.NewLine + Environment.NewLine;
            var index = text.IndexOf(searchFor, pos);
            if(index == -1)
            {
                return false;
            }
            pos = index;
            return true;
        }

        public static void FileCheck(string fileName)
        {
            string text;
            if (File.Exists(fileName))
            {
                text = File.ReadAllText(fileName);
                AddHTMTTags();

                var textArray = new List<string>();

                GetParagraphs(text, textArray);

                PrintPTags(textArray);

                AddHTMTTags();
            }
            else
            {
                Console.Error.WriteLine("Error: File doesn't exist");
            }
        }

        private static void AddHTMTTags()
        {
            Console.WriteLine("<html>");
            Console.WriteLine("<body>");
        }

        private static void PrintPTags(List<string> textArray)
        {
            foreach (var element in textArray)
            {
                Console.WriteLine("<p>");
                Console.WriteLine(element);
                Console.WriteLine("</p>");
            }
        }

        private static List<string> GetParagraphs(string text, List<string> textArray)
        {
            int pos = 0, prevPos = pos;
            while (GetParagraphBreak(ref pos, text))
            {
                textArray.Add(text.Substring(prevPos, pos - prevPos));
                pos += Environment.NewLine.Length * 2;
                prevPos = pos;
            }
            textArray.Add(text.Substring(pos, text.Length - pos));
            return textArray;
        }
    }
}
