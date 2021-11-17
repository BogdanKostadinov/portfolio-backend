using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Portfolio.Api.Controllers;
using Portfolio.Api.DTOs;
using Portfolio.Api.Models;
using Portfolio.Api.Repositories;
using Xunit;

namespace Portfolio.UnitTests
{
    public class FeedbackControllerTest
    {
        private readonly Mock<IFeedbackRepository> repositoryStub = new();
        private readonly Mock<ILogger<FeedbackController>> loggerStub = new();

        //NAMING CONVENTION
        //UnitOfWork_StateUnderTest_ExpectedBehavior

        [Fact]
        public async Task GetFeedbackAsync_WithUnexistingItem_ReturnsNotFound()
        {
            //Arrange
            repositoryStub.Setup(repo => repo.GetFeedbackAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Feedback)null);

            var loggerStub = new Mock<ILogger<FeedbackController>>();

            var controller = new FeedbackController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.GetFeedbackAsync(Guid.NewGuid());

            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetFeedbackAsync_WithExistingItem_ReturnsExpectedItem()
        {
            //Arrange
            var expectedItem = CreateRandomFeedback();
            repositoryStub.Setup(repo => repo.GetFeedbackAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedItem);
            var controller = new FeedbackController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.GetFeedbackAsync(Guid.NewGuid());

            //Assert
            result.Value.Should().BeEquivalentTo(expectedItem, options => options.ComparingByMembers<Feedback>());
        }

        [Fact]
        public async Task GetFeedbacksAsync_WithExistingItems_ReturnsAllItems()
        {
            //Arrange
            var expectedFeedbacks = new List<Feedback>() { };
            expectedFeedbacks.Add(CreateRandomFeedback());
            expectedFeedbacks.Add(CreateRandomFeedback());
            expectedFeedbacks.Add(CreateRandomFeedback());


            repositoryStub.Setup(repo => repo.GetFeedbacksAsync())
                .ReturnsAsync(expectedFeedbacks);

            var controller = new FeedbackController(repositoryStub.Object, loggerStub.Object);

            //Act
            var returnedItems = await controller.GetFeedbacksAsync();

            //Assert
            returnedItems.Should().BeEquivalentTo(expectedFeedbacks, options => options.ComparingByMembers<Feedback>());
        }

        [Fact]
        public async Task CreateFeedbacksAsync_CreateFeedback_ReturnsCreatedFeedback()
        {
            var feedbackToCreate = new CreateFeedbackDTO(){
                Name = Guid.NewGuid().ToString(),
                Message = Guid.NewGuid().ToString()
                
            };
            
            var controller = new FeedbackController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.CreateFeedbackAsync(feedbackToCreate);

            var createdFeedback = (result.Result as CreatedAtActionResult).Value as FeedbackDTO;

            feedbackToCreate.Should().BeEquivalentTo(createdFeedback, options => options.ComparingByMembers<FeedbackDTO>().ExcludingMissingMembers());

            createdFeedback.Id.Should().NotBeEmpty();
        }

        private Feedback CreateRandomFeedback()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Message = Guid.NewGuid().ToString()
            };
        }
    }
}
