using FluentAssertions;
using Identity.Api.Controllers;
using Identity.Application.DataTransferModels.OutPutDtos;
using Identity.Application.Interfaces.PersonInterfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Identity.Test
{
    public class PersonTest
    {
        [Fact]
        [Trait("UnCertain", "Test")]
        public async Task Test1()
        {
            //Arrange
            PersonController personController = new PersonController();

            //Act
            OkObjectResult result = (OkObjectResult)await personController.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        [Trait("UnCertain", "Test2")]
        public async Task TestWithServices()
        {
            //Arrange
            var mockServices = new Mock<IPersonService>();
            mockServices.Setup(service=> service.GetAllPersons()).ReturnsAsync(new List<PersonOutputDto>());

            PersonController personController = new PersonController(mockServices.Object);

            //Act
            OkObjectResult result = (OkObjectResult)await personController.GetAllPersons();

            //Assert
            mockServices.Verify(services=> services.GetAllPersons(), Times.Once());
        }
    }
}