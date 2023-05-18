using AutoMapper;
using Employee.Management.Application.Features.Employee.Querys.GetAllEmployees;
using Employee.Management.Application.Features.Employee.Querys.GetEmployeeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Management.Domain;
using Employee.Management.Application.Features.Employee.Commands.CreateEmployee;
using Employee.Management.Application.Features.Employee.Commands.UpdateEmployee;

namespace Employee.Management.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {

        public EmployeeProfile()
        {
            CreateMap<EmployeeDTO, Domain.Employee>().ReverseMap();
            CreateMap<Domain.Employee, EmployeeDetailsDTO>();
            CreateMap<CreateEmployeeCommand, Domain.Employee>();
            CreateMap<UpdateEmployeeCommand, Domain.Employee>();
        }
    }
}
