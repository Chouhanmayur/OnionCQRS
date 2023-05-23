using Employee.Management.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Management.Domain;

namespace Employee.Management.Persistence.DataBaseContext
{
    public class EmployeeDatabaseContext : DbContext
    {

        public EmployeeDatabaseContext(DbContextOptions<EmployeeDatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Domain.Employee> Employees { get; set;}

        public DbSet<Domain.City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeDatabaseContext).Assembly);

           

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //to auto increment or datetime 
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
               
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
