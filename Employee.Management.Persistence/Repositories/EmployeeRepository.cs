using Employee.Management.Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Management.Domain;
using Microsoft.EntityFrameworkCore;
using Employee.Management.Application.Contracts.Persistence;

namespace Employee.Management.Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Domain.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsEmployeeUnique(string name)
        {
            return await _context.Employees.AnyAsync(q => q.Name == name) == false;
        }
    }
}
