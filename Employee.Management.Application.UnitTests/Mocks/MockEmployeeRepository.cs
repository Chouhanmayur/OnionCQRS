using Employee.Management.Application.Contracts.Persistence;
using Employee.Management.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.UnitTests.Mocks
{
    public class MockEmployeeRepository
    {
        public static Mock<IEmployeeRepository> GetEmployeeTypeRepository()
        {
            var Employees = new List<Domain.Employee>
            { new Domain.Employee {
           
            City = "Indore",
            Name = "unit Test",
            Department = "CS",
            Gender = "Male"
            }};

            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(Employees);
            //mockRepo.Setup(r => r.CreateAsync(It.IsAny<Domain.Employee>()))
            //    .Returns((Domain.Employee employee) =>
            //    {
            //        Employees.Add(employee);
            //        return Task.CompletedTask;
            //    });

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Domain.Employee>()))
     .Returns((Domain.Employee employee) =>
     {
         Employees.Add(employee);
         return Task.FromResult(employee); // Return Task<Employee> instead of Task
     });

            return mockRepo;
        }

    }
}
