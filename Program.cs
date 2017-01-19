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
        const int ERROR_BAD_COMMAND = 22;

        const ConsoleColor ErrColor = ConsoleColor.Red;
        const ConsoleColor ErrColorDetail = ConsoleColor.DarkYellow;

        public static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string result = ConvertFile(args[0]);
                Console.WriteLine(result);
            }
            else
            {
                ConsoleColor startFg = Console.ForegroundColor;
                Console.ForegroundColor = ErrColor;
                Console.Error.Write("Error: ");
                Console.ForegroundColor = ErrColorDetail;
                Console.Error.WriteLine("Insert one argument only");
                Console.ForegroundColor = startFg;
                Environment.Exit(ERROR_BAD_COMMAND);
            }
        }

        private static string ConvertFile(string fileName)
        {
            try
            {
                string text = File.ReadAllText(fileName);
                // Ordering of this part is important!
                text = AddParagraphTags(text);
                text = AddFileTags(text);
                return text;
            }
            catch (Exception ex)
            {
                ConsoleColor startFg = Console.ForegroundColor;
                Console.ForegroundColor = ErrColor;
                Console.Error.Write("Error: ");
                Console.ForegroundColor = ErrColorDetail;
                Console.Error.Write("Failed to convert " + fileName + ", reason: ");
                Console.ForegroundColor = startFg;
                Console.Error.WriteLine(ex);
            }
            return null;
        }

        private static string AddParagraphTags(string text)
        {
            var value = new StringBuilder();
            List<string> paragraphs = ListParagraphs(text);
            foreach (var paragraph in paragraphs)
            {
                value.AppendLine("<p>");
                value.AppendLine(paragraph);
                value.AppendLine("</p>");
            }
            return value.ToString();
        }

        private static string AddFileTags(string text)
        {
            var value = new StringBuilder();
            value.AppendLine("<html>");
            value.AppendLine("<body>");
            value.AppendLine(text);
            value.AppendLine("</body>");
            value.AppendLine("</html>");
            return value.ToString();
        }

        private static List<string> ListParagraphs(string text)
        {
            var textArray = new List<string>();
            int pos = 0;
            int prevPos = pos;
            while (GetParagraphBreak(ref pos, text))
            {
                textArray.Add(text.Substring(prevPos, pos - prevPos));
                pos += Environment.NewLine.Length * 2;
                prevPos = pos;
            }
            textArray.Add(text.Substring(pos, text.Length - pos));
            return textArray;
        }

        private static bool GetParagraphBreak(ref int pos, string text)
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
    }
}
