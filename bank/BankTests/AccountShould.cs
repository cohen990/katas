using System;
using Xunit;

namespace BankTests
{
    public class AccountShould
    {
        [Fact]
        public void PrintStatementContainingAllTransactions()
        {
            var account = new Account();
            account.deposit(1000);
            account.withdraw(100);
            account.deposit(500);

            account.printStatement();

            verify(console).printLine("DATE | AMOUNT | BALANCE");
            verify(console).printLine("10/04/2014 | 500.00 | 1400.00");
            verify(console).printLine("02/04/2014 | -100.00 | 900.00");
            verify(console).printLine("01/04/2014 | 1000.00 | 1000.00");
        }
    }
}
