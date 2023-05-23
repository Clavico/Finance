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
using Finance.Application.UseCases.GetTransaction;

namespace Finance.Tests.UseCases
{
    public class GetTransactionTests
    {
        [Fact]
        public async Task Should_ReturnTransaction()
        {
            // Arrange
            var request = new GetTransactionInput(1);

            var transaction = new Transaction("Test Transaction", 100, eType.Payable, DateTime.Now);

            var mockRepository = new Mock<ITransactionRepository>();
            mockRepository
                .Setup(repo => repo.Get(request.Id))
                .ReturnsAsync(transaction);

            var handler = new GetTransaction(mockRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Output>();
            result.Result.Should().BeEquivalentTo(transaction);
        }
    }
}
