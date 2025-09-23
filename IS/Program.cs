using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                int firstQuote = line.IndexOf('"');
                int lastQuote = line.LastIndexOf('"');

                string fileName = line.Substring(firstQuote + 1,
                    lastQuote - firstQuote - 1);

                string remaining = line.Substring(lastQuote + 1).Trim();

                string[] parts = remaining.Split(' ');
                DateTime creationDate = DateTime.Parse(parts[0]);
                int size = int.Parse(parts[1]);
                InputFile file = new InputFile(fileName, creationDate, size);
                files.Add(file);

                Console.WriteLine("Файл: " + fileName);
                Console.WriteLine("Дата создания: " + creationDate);
                Console.WriteLine("Размер: " + size + " байт");
                Console.WriteLine(new string('-', 30));

            }
            InputFile maxSize = MaxSize(files);
            Console.WriteLine("\nМаксимальный размер: " + maxSize.Size + " байт");
            Console.ReadKey();
        }
        public static InputFile MaxSize(List<InputFile> files)
        {
            InputFile MaxFile = files[0];   
            foreach (InputFile file in files)
            {
                if (MaxFile.Size < file.Size)
                {
                    MaxFile = file;
                }
            }

            return MaxFile;
        }
    }
}