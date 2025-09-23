using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    internal class FileAnalyzer
    {
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
