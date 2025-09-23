using IS.Services;
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
                InputFile item = FileParser.ParseLine(line);
                if (item != null)
                {
                    files.Add(item);
                }
            }

            FilePrinter.PrintFiles(files);
        }
    }
}