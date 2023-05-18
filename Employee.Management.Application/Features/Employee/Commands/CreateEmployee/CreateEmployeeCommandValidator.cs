using Employee.Management.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandValidator(IEmployeeRepository employeeRepository)
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.City)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.Gender)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(p => p.Department)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull()
                 .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(q => q)
                .MustAsync(EmployeeNameUnique)
                .WithMessage("Employee already exists");
            this._employeeRepository = employeeRepository;
        }

        private Task<bool> EmployeeNameUnique(CreateEmployeeCommand command, CancellationToken token)
        {
            return _employeeRepository.IsEmployeeUnique(command.Name);
        }
    }
}
