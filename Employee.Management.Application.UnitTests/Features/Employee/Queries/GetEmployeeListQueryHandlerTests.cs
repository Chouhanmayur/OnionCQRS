using AutoMapper;
using Employee.Management.Application.Contracts.Logging;
using Employee.Management.Application.Contracts.Persistence;
using Employee.Management.Application.Features.Employee.Querys.GetAllEmployees;
using Employee.Management.Application.MappingProfiles;
using Employee.Management.Application.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Employee.Management.Application.UnitTests.Features.Employee.Queries
{
    public class GetEmployeeListQueryHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetEmployeeQueryHandler>> _mockAppLogger;

        public GetEmployeeListQueryHandlerTests()
        {
            _mockRepo = MockEmployeeRepository.GetEmployeeTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
             {
                 c.AddProfile<EmployeeProfile>();
                 });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetEmployeeQueryHandler>>();
        }


        [Fact]
        public async Task GetEmployeeListTest()
        {
            var handler = new GetEmployeeQueryHandler (_mapper, _mockRepo.Object, 
                _mockAppLogger.Object);

            var result = await handler.Handle(new GetEmployeeQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<EmployeeDTO>>();
            result.Count.ShouldBe(1);

        }
    }
}
