using Xunit;
using Moq;
using FluentAssertions;
using System.Threading;
using Finance.Domain.Models;
using Finance.Domain.Interfaces;
using Finance.Application.UseCases.CreateTransaction;
using Finance.Application.UseCases.Core;
using System.Threading.Tasks;
using System;
using Finance.Domain.Enums;

namespace Finance.Tests.UseCases
{
    public class CreateTransactionTests
    {
        [Fact]
        public async Task Should_CreateTransaction()
        {
            // Arrange
            var request = new CreateTransactionInput
            {
                Description = "Test Transaction",
                Value = 100,
                Type = eType.Payable,
                Date = DateTime.Now
            };

            var mockRepository = new Mock<ITransactionRepository>();
            mockRepository
                .Setup(repo => repo.Add(It.IsAny<Transaction>()))
                .Returns(Task.CompletedTask);

            var handler = new CreateTransaction(mockRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Output>();
            mockRepository.Verify(repo => repo.Add(It.Is<Transaction>(
                t => t.Description == request.Description &&
                     t.Value == request.Value &&
                     t.Type == request.Type &&
                     t.Date == request.Date)), Times.Once);
        }
    }
}
