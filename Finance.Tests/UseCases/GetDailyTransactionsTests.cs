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
using Finance.Application.UseCases.GetDailyTransactions;
using System.Linq;

namespace Finance.Tests.UseCases
{
    public class GetDailyTransactionsTests
    {
        [Fact]
        public async Task Should_ReturnTransactionsGroupedByDate_WithoutDate()
        {
            // Arrange
            var request = new GetDailyTransactionsInput { Date = null };

            var transactions = new List<Transaction>
            {
                new Transaction("Transaction 1", 100, eType.Payable, DateTime.Now.Date),
                new Transaction("Transaction 2", 200, eType.Receivable, DateTime.Now.Date),
                new Transaction("Transaction 3", 300, eType.Receivable, DateTime.Now.Date.AddDays(1)),
                new Transaction("Transaction 4", 400, eType.Payable, DateTime.Now.Date.AddDays(1))
            };

            var mockRepository = new Mock<ITransactionRepository>();
            mockRepository
                .Setup(repo => repo.GetAll())
                .ReturnsAsync(transactions);

            var handler = new GetDailyTransactions(mockRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Output>();
            result.Result.Should().BeEquivalentTo(new[]
            {
                new { Date = DateTime.Now.Date.ToString("dd/MM/yyyy"), Payable = 100, Receivable = 200, Amount = 100 },
                new { Date = DateTime.Now.Date.AddDays(1).ToString("dd/MM/yyyy"), Payable = 400, Receivable = 300, Amount = -100 }
            }, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task Should_ReturnTransactionsGroupedByDate_WithDate()
        {
            // Arrange
            var date = DateTime.Now.Date;
            var request = new GetDailyTransactionsInput { Date = date };

            var transactions = new List<Transaction>
            {
                new Transaction("Transaction 1", 100, eType.Payable, date),
                new Transaction("Transaction 2", 200, eType.Receivable, date),
                new Transaction("Transaction 3", 300, eType.Receivable, date.AddDays(1)),
                new Transaction("Transaction 4", 400, eType.Payable, date.AddDays(1))
            };

            var mockRepository = new Mock<ITransactionRepository>();
            mockRepository
                .Setup(repo => repo.GetByDate(date.ToUniversalTime(), date.AddDays(1).ToUniversalTime()))
                .ReturnsAsync(transactions.Where(t => t.Date >= date && t.Date < date.AddDays(1)));

            var handler = new GetDailyTransactions(mockRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeOfType<Output>();
            result.Result.Should().BeEquivalentTo(new[]
            {
                new { Date = date.ToString("dd/MM/yyyy"), Payable = 100, Receivable = 200, Amount = 100 }
            }, options => options.ExcludingMissingMembers());
        }
    }
}
