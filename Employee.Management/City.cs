using Employee.Management.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Domain
{
    public class City : BaseEntity
    {
       
        public string Name { get; set; } = string.Empty;
    }
}
