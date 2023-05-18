using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}
