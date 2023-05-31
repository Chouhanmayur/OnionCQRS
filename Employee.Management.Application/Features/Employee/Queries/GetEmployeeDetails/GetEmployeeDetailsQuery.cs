using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Querys.GetEmployeeDetails
{
    public record GetEmployeeDetailsQuery(int id) : IRequest<EmployeeDetailsDTO>;
   
}
