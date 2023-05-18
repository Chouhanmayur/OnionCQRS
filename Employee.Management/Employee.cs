using Employee.Management.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Domain
{
    public class Employee : BaseEntity
    {

        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

    }
}