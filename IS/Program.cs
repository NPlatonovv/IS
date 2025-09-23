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

            foreach (var line in lines)
            {
                InputFile file = ParseLine(line);
                if (file != null)
                    files.Add(file);
            }

            foreach (var f in files)
            {
                PrintFile(f);
            }


            InputFile maxFile = MaxSize(files);
            Console.WriteLine($"\nМаксимальный размер: {maxFile.Size} байт");
            Console.ReadKey();
        }
        static InputFile ParseLine(string line)
        {
            int firstQuote = line.IndexOf('"');
            int lastQuote = line.LastIndexOf('"');
            if (firstQuote == -1 || lastQuote == -1) return null;

            string name = line.Substring(firstQuote + 1, lastQuote - firstQuote - 1);
            string remaining = line.Substring(lastQuote + 1).Trim();
            string[] parts = remaining.Split(' ');

            DateTime creationDate = DateTime.Parse(parts[0]);
            int size = int.Parse(parts[1]);

            string org = null;
            int? dept = null;
            FileType? type = null;

            foreach (string token in parts.Skip(2))
            {
                string[] kv = token.Split('=');
                if (kv.Length != 2) continue;

                switch (kv[0].ToLower())
                {
                    case "type":
                        if (Enum.TryParse(kv[1], true, out FileType t)) type = t;
                        break;
                    case "org":
                        org = kv[1];
                        break;
                    case "dept":
                        if (int.TryParse(kv[1], out int d)) dept = d;
                        break;
                }
            }
            if (type.HasValue) return new TypedFile(name, creationDate, size, type.Value);
            if (org != null) return new OrganizationFile(name, creationDate, size, org, dept);

            return new InputFile(name, creationDate, size);
        }

        static void PrintFile(InputFile file)
        {
            Console.WriteLine($"Файл: {file.Name}");
            Console.WriteLine($"Дата создания: {file.CreationDate:yyyy-MM-dd}");
            Console.WriteLine($"Размер: {file.Size} байт");
            Console.WriteLine(new string('-', 30));
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