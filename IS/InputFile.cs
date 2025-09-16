using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    internal class InputFile
    {
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public int Size { get; set; }

        public InputFile(string name, string creationDate, int size)
        {
            Name = name;
            CreationDate = creationDate;
            Size = size;
        }

    }
}
