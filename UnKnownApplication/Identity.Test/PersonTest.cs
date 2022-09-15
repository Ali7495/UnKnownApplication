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



        // To test the service
        [Fact]
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


        // To determine the type of the output
        [Fact]
        public async Task SuccessOnTypeOfPersonList()
        {
            //Arrange
            var mockServices = new Mock<IPersonService>(MockBehavior.Strict);
            mockServices.Setup(services=> services.GetAllPersons()).ReturnsAsync(new List<PersonOutputDto>());

            PersonController personController = new PersonController(mockServices.Object);

            //Act
            var result = await personController.GetAllPersons();


            //Assert
            result.Should().BeOfType<OkObjectResult>();
            OkObjectResult objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<PersonOutputDto>>();
        }
    }
}