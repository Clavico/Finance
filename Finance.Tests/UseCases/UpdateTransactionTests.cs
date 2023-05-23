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
using System.Collections.Generic;
using Finance.Application.UseCases.GetAllTransactions;
using Finance.Application.UseCases.UpdateTransaction;

namespace Finance.Tests.UseCases
{
    public class UpdateTransactionTests
    {
        [Fact]
        public async Task Should_UpdateTransaction()
        {
            // Arrange
            var request = new UpdateTransactionInput
            {
                Id = 1,
                Description = "Updated Transaction",
                Value = 200,
                Type = eType.Receivable,
                Date = DateTime.Now
            };

            var mockRepository = new Mock<ITransactionRepository>();
            mockRepository
                .Setup(repo => repo.Edit(It.IsAny<Transaction>()))
                .Returns(Task.CompletedTask);

            var handler = new UpdateTransaction(mockRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Output>();
            mockRepository.Verify(repo => repo.Edit(It.IsAny<Transaction>()), Times.Once);
        }
    }
}
