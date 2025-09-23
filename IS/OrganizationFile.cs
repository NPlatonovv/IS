using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    internal class OrganizationFile: InputFile
    {
        public string Organization { get; set; }
        public int? DepartmentCode { get; set; }
        public OrganizationFile (string name, DateTime creationDate, int size, string organization, int departmentCode)
            : base(name,creationDate,size)
        {
            Organization = organization;
            DepartmentCode = departmentCode;
        }
    }
}
