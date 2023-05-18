using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Querys.GetAllEmployees
{
    //public class GetEmployeeQuery : IRequest<List<EmployeeDTO>>
    //{
    //}


    //immutable
    public record GetEmployeeQuery : IRequest<List<EmployeeDTO>>;
}
