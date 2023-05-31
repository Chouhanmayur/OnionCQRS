using AutoMapper;
using Employee.Management.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Querys.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeDetailsQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDetailsDTO> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var employeeDetails = await _employeeRepository.GetByIdAsync(request.id);

            var data = _mapper.Map<EmployeeDetailsDTO>(employeeDetails);

            return data;
        }
    }
}
