using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Management.Domain;
using Employee.Management.Application.Exceptions;
using Employee.Management.Application.Contracts.Persistence;
using Employee.Management.Application.Contracts.Logging;

namespace Employee.Management.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAppLogger<CreateEmployeeCommandHandler> _logger;

        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository,
            IAppLogger<CreateEmployeeCommandHandler> logger)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
            this._logger = logger;
        }


        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateEmployeeCommandValidator(_employeeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("validation error occured");
                throw new BadRequestException("Invalid Employee data", validationResult);
            }
            var employeeToCreate =  _mapper.Map<Domain.Employee>(request);
            await _employeeRepository.CreateAsync(employeeToCreate);
            return employeeToCreate.Id;
        }
    }
}
