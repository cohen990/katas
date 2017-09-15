using System;
using Xunit;
using Bank;
using Moq;

namespace BankTests
{
    public class AccountShould
    {
        [Fact]
        public void PrintEmptyStatementOnNewAccount()
        {
            var writer = new Mock<Writer>();
            var account = new Account(writer.Object);

            account.PrintStatement();

            writer.Verify(x => x.WriteLine("AMOUNT | BALANCE"), Times.Once);
            writer.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void PrintStatementWithOneDeposit()
        {
            var writer = new Mock<Writer>();
            var account = new Account(writer.Object);
            
            account.Deposit(10);
            account.PrintStatement();

            writer.Verify(x => x.WriteLine("AMOUNT | BALANCE"), Times.Once);
            writer.Verify(x => x.WriteLine("10.00 | 10.00"), Times.Once);
            writer.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(2));
        }

        [Fact]
        public void PrintStatementWithOneWithdrawal()
        {
            var writer = new Mock<Writer>();
            var account = new Account(writer.Object);
            
            account.Withdraw(10);
            account.PrintStatement();

            writer.Verify(x => x.WriteLine("AMOUNT | BALANCE"), Times.Once);
            writer.Verify(x => x.WriteLine("-10.00 | -10.00"), Times.Once);
            writer.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(2));
        }

        [Fact]
        public void PrintStatementWithOneDepositAndOneWithdrawal()
        {
            var writer = new Mock<Writer>();
            var account = new Account(writer.Object);
            
            account.Deposit(20);
            account.Withdraw(10);
            account.PrintStatement();

            writer.Verify(x => x.WriteLine("AMOUNT | BALANCE"), Times.Once);
            writer.Verify(x => x.WriteLine("-10.00 | 10.00"), Times.Once);
            writer.Verify(x => x.WriteLine("20.00 | 20.00"), Times.Once);
            writer.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }

        [Fact]
        public void PrintStatementWithTwoDepositsAndTwoWithdrawals()
        {
            var writer = new Mock<Writer>();
            var account = new Account(writer.Object);
            
            account.Deposit(20);
            account.Withdraw(10);
            account.Deposit(40);
            account.Withdraw(50);
            account.PrintStatement();

            writer.Verify(x => x.WriteLine("AMOUNT | BALANCE"), Times.Once);
            writer.Verify(x => x.WriteLine("-50.00 | 0.00"), Times.Once);
            writer.Verify(x => x.WriteLine("40.00 | 50.00"), Times.Once);
            writer.Verify(x => x.WriteLine("-10.00 | 10.00"), Times.Once);
            writer.Verify(x => x.WriteLine("20.00 | 20.00"), Times.Once);
            writer.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(5));
        }
    }
}
