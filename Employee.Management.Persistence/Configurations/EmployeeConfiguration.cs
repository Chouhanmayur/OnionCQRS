using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Employee.Management.Domain;

namespace Employee.Management.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Domain.Employee>
    {
        public void Configure(EntityTypeBuilder<Domain.Employee> builder)
        {
            builder.HasData(
               new Domain.Employee
               {
                   Id = 1,
                   City = "Indore",
                   Department = "CS",
                   Gender = "M",
                   Name = "Test"

               }
               );
           
        }
    }
}
