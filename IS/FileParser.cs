using System;
using System.Linq;

namespace IS.Services
{
    public static class FileParser
    {
        public static InputFile ParseLine(string line)
        {
            int firstQuote = line.IndexOf('"');
            int lastQuote = line.LastIndexOf('"');
            if (firstQuote == -1 || lastQuote == -1) return null;

            string name = line.Substring(firstQuote + 1, lastQuote - firstQuote - 1);
            string remaining = line.Substring(lastQuote + 1).Trim();
            string[] parts = remaining.Split(' ');

            DateTime creationDate = DateTime.Parse(parts[0]);
            int size = int.Parse(parts[1]);
            bool isExecutable = bool.Parse(parts[2]);

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

            if (type.HasValue)
            {
                return new TypedFile(name, creationDate, size, isExecutable, type.Value);
            }

            if (org != null)
            {
                return new OrganizationFile(name, creationDate, size, isExecutable, org, dept);
            }

            return new InputFile(name, creationDate, size, isExecutable);
        }
    }

}