using IS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IS
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<InputFile> files = new List<InputFile>();
            string[] lines = File.ReadAllLines("input.txt");

            foreach (string line in lines)
            {
                InputFile item = FileParser.ParseLine(line);
                if (item != null)
                {
                    files.Add(item);
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Вывести все файлы");
                Console.WriteLine("2. Добавить файл");
                Console.WriteLine("3. Удалить файл");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FilePrinter.PrintFiles(files);
                        break;
                    case "2":
                        Console.WriteLine("Введите данные файла");
                        var line = Console.ReadLine();
                        InputFile item = FileParser.ParseLine(line);
                        if (item != null)
                        {
                            files.Add(item);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите имя файла");
                        var fileName = Console.ReadLine();
                        files.RemoveAll(s => s.Name == fileName);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}