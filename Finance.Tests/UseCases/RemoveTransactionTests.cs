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
using Finance.Application.UseCases.RemoveTransaction;

namespace Finance.Tests.UseCases
{
    public class RemoveTransactionTests
    {
        [Fact]
        public async Task Should_DeleteTransaction()
        {
            // Arrange
            var request = new RemoveTransactionInput(1);

            var mockRepository = new Mock<ITransactionRepository>();
            mockRepository
                .Setup(repo => repo.Delete(request.Id))
                .Returns(Task.CompletedTask);

            var handler = new RemoveTransaction(mockRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Output>();
            mockRepository.Verify(repo => repo.Delete(request.Id), Times.Once);
        }
    }
}
