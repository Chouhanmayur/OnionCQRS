using Employee.Management.Domain;
namespace Employee.Management.Application.Contracts.Persistence;


public interface IEmployeeRepository : IGenericRepository<Domain.Employee>
{
    Task<bool> IsEmployeeUnique(string name);
}
