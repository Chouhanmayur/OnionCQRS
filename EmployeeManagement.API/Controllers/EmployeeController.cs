using Employee.Management.Application.Features.Employee.Commands.CreateEmployee;
using Employee.Management.Application.Features.Employee.Commands.DeleteEmployee;
using Employee.Management.Application.Features.Employee.Commands.UpdateEmployee;
using Employee.Management.Application.Features.Employee.Querys.GetAllEmployees;
using Employee.Management.Application.Features.Employee.Querys.GetEmployeeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<Employee>
        [HttpGet]
        public async Task<List<EmployeeDTO>> Get()
        {
           var employeeList = await _mediator.Send(new GetEmployeeQuery());
            return employeeList;
        }

        // GET api/<Employee>/5
        [HttpGet("{id}")]
        public async Task<EmployeeDetailsDTO> Get(int id)
        {
            var employeeDetails = await _mediator.Send(new GetEmployeeDetailsQuery(id));
            return employeeDetails;
        }

        // POST api/<Employee>
        [HttpPost]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateEmployeeCommand employee)
        {
            var response = await _mediator.Send(employee);
            return CreatedAtAction(nameof(Get), new {id = response});
        }

        // PUT api/<Employee>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateEmployeeCommand Employee)
        {
            await _mediator.Send(Employee);
            return NoContent();
        }

        // DELETE api/<Employee>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
