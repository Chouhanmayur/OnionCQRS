using AutoMapper;
using Employee.Management.Application.Contracts.Logging;
using Employee.Management.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Querys.GetAllEmployees
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<EmployeeDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAppLogger<GetEmployeeQueryHandler> _logger;

        public GetEmployeeQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository, IAppLogger<GetEmployeeQueryHandler> logger)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
            this._logger = logger;
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var employees = await _employeeRepository.GetAsync();

            //convert data objects to DTO objects
           var data = _mapper.Map<List<EmployeeDTO>>(employees);

            _logger.LogInformation("employee list successfully retrived");

            //return list of DTO objects
            return data;
        }
    }
}
