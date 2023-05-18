using AutoMapper;
using Employee.Management.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToUpdate = _mapper.Map<Domain.Employee>(request);
            await _employeeRepository.UpdateAsync(employeeToUpdate);
            return Unit.Value;
        }
    }
}
