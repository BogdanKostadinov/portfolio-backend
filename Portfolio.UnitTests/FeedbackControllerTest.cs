using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Portfolio.Api.Controllers;
using Portfolio.Api.Models;
using Portfolio.Api.Repositories;
using Xunit;

namespace Portfolio.UnitTests
{
    public class FeedbackControllerTest
    {
        //NAMING CONVENTION
        //UnitOfWork_StateUnderTest_ExpectedBehavior

        [Fact]
        public async Task GetFeedbacksAsync_WithUnexistingItem_ReturnsNotFound()
        {
            //Arrange
            var repositoryStub = new Mock<IFeedbackRepository>();
            repositoryStub.Setup(repo => repo.GetFeedbackAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Feedback)null);

            var loggerStub = new Mock<ILogger<FeedbackController>>();

            var controller = new FeedbackController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.GetFeedbackAsync(Guid.NewGuid());

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);

        }
    }
}
