using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Common;

// public abstract class AuditableEntity
public abstract class BaseEntity
{
    public int Id { get; set; }

    // public DateTime? CreatedDate { get; set; }
   // public DateTime? ModifyDate { get; set; }

}
