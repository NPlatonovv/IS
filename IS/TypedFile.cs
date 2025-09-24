using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    internal class TypedFile: InputFile
    {
        public FileType Type { get; set; }
        public TypedFile (string name, DateTime creationDate, int size, bool isExecutable, FileType type)
            :base(name,creationDate, size, isExecutable)
        {
            Type = type;
        }
    }
}
