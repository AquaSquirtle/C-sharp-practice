using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Checks;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Checks;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class BankingSystemTest
{
    [Fact]
    public void MoneyManipulationTest()
    {
        var checkRepository = new Mock<ICheckRepository>();
        checkRepository.Setup(repo => repo.FindCheckByNumber(12345))
            .Returns(new Check(12345, 123, 100.0m));
        var transactionRepository = new Mock<ITransactionRepository>();
        var currentCheck = new CurrentCheckService();
        var service = new CheckService(checkRepository.Object, currentCheck, transactionRepository.Object);
        service.LoadCheck(12345, 123);
        service.TryWithdraw(100);
        Assert.Equal(0m, currentCheck.Check?.Balance);
        checkRepository.Verify(repo => repo.UpdateCheckMoney(12345, 100), Times.Once);
        Assert.True(service.TryWithdraw(400) is CheckServiceResult.CheckServiceError);
        service.TryDeposit(1000);
        Assert.Equal(1000m, currentCheck.Check?.Balance);
        checkRepository.Verify(repo => repo.UpdateCheckMoney(12345, 1000), Times.Once);
    }
}