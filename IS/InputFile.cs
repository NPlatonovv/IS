using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    public class InputFile
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int Size { get; set; }
        public bool IsExecutable { get; set; }
        

        public InputFile(string name, DateTime creationDate, int size, bool isExecutable)
        {
            Name = name;
            CreationDate = creationDate;
            Size = size;
            IsExecutable = isExecutable;
        }

    }
}
