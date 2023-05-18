using Employee.Management.Application.Contracts.Persistence;
using Employee.Management.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var employeeToDelete = await _employeeRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (employeeToDelete == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            // remove from database
            await _employeeRepository.DeleteAsync(employeeToDelete);

            // retun record id
            return Unit.Value;
        }
    }
}
