using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    internal class FilePrinter
    {
        public static void PrintFile(InputFile file)
        {
            Console.WriteLine($"Файл: {file.Name}");
            Console.WriteLine($"Дата создания: {file.CreationDate:yyyy-MM-dd}");
            Console.WriteLine($"Размер: {file.Size} байт");
            Console.WriteLine(new string('-', 30));
        }
        public static void PrintFiles(List<InputFile> files)
        {
            foreach (var file in files)
            {
                PrintFile(file);
            }
        }
    }
}
