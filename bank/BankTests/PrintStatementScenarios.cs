using Bank;
using Moq;
using Moq.Language.Flow;
using Xunit;

namespace BankTests
{
    public class PrintStatementScenarios
    {
        private Account _account;
        private readonly Mock<Writer> _writerMock;

        public PrintStatementScenarios()
        {
            _writerMock = new Mock<Writer>();
        }
        
        [Fact]
        public void BankStatementWithDepositsAndWithdrawals ()
        {
            var printedStatementLines = new[]
            {
                "AMOUNT | BALANCE",
                "-500.00 | 1300.00",
                "2000.00 | 1800.00",
                "-200.00 | -200.00",
            };
            
            Given_a_new_bank_account();
            
            When_I_withdraw(200);
            And_I_deposit(2000);
            And_I_withdraw(500);
            And_I_print_a_statement();
            
            Then_print_statement_should_be(printedStatementLines);
        }

        private void Given_a_new_bank_account()
        {
            _account = new Account(_writerMock.Object);
        }

        private void When_I_withdraw(int amount)
        {
            _account.Withdraw(amount);
        }

        private void And_I_deposit(int amount)
        {
            _account.Deposit(amount);
        }

        private void And_I_withdraw(int amount)
        {
            _account.Withdraw(amount);
        }

        private void And_I_print_a_statement()
        {
            _account.PrintStatement();
        }

        private void Then_print_statement_should_be(string[] printedStatementLines)
        {
            foreach (var line in printedStatementLines)
            {
                _writerMock.Verify(x => x.WriteLine(line), Times.Once);
            }
            
            _writerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(printedStatementLines.Length));
        }
    }
}