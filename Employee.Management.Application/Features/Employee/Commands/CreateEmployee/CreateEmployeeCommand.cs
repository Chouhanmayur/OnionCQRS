using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}
