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

namespace Finance.Tests.UseCases
{
    public class GetAllTransactionTests
    {
        [Fact]
        public async Task Should_ReturnAllTransactions()
        {
            // Arrange
            var request = new GetAllTransactionsInput();

            var transactions = new List<Transaction>
            {
                new Transaction("Transaction 1", 100, eType.Payable, DateTime.Now),
                new Transaction("Transaction 2", 200, eType.Receivable, DateTime.Now),
                new Transaction("Transaction 3", 300, eType.Payable, DateTime.Now)
            };

            var mockRepository = new Mock<ITransactionRepository>();
            mockRepository
                .Setup(repo => repo.GetAll())
                .ReturnsAsync(transactions);

            var handler = new GetAllTransactions(mockRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Output>();
            result.Result.Should().BeEquivalentTo(transactions);
        }
    }
}
