using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab9_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            Console.Write("Имя файла: ");
            string fileName = Console.ReadLine();
            while (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден!");
                Console.Write("Имя файла: ");
                fileName = Console.ReadLine();
            }
            using (StreamReader readrer = new StreamReader(fileName))
            {
                text = readrer.ReadToEnd();
            }
            const string myReg1 = @"(get\s+){(\s+[a-zA-Z\s+]+[^\s;]*);+\s+}";
            MatchCollection match1 = Regex.Matches(text, myReg1, RegexOptions.IgnoreCase);
            findMyText(text, match1);


        }
        static void findMyText(string text, MatchCollection myMatch)
        {
            Console.WriteLine("\n\nИсходная строка:\n\n{0}\n\nВидоизмененная строка:\n", text);

            // Реализуем выделение ключевых слов в консоли другим цветом
            for (int i = 0; i < text.Length; i++)
            {
                foreach (Match m in myMatch)
                {
                    if ((i >= m.Index) && (i < m.Index + m.Length))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.Write(text[i]);
            }

        }
    }
}