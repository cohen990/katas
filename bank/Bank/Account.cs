using System;
using System.Collections.Generic;

namespace Bank
{
    public class Account : BankAccount
    {
        private readonly Writer _writer;
        private readonly List<int> _transactionAmounts;
        
        public Account(Writer writer)
        {
            _writer = writer;
            _transactionAmounts = new List<int>();
        }

        public void Deposit(int amount)
        {
            _transactionAmounts.Add(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionAmounts.Add(-1 * amount);
        }

        public void PrintStatement()
        {
            var balance = 0;
            _writer.WriteLine("AMOUNT | BALANCE");
            foreach (var transactionAmount in _transactionAmounts)
            {
                balance += transactionAmount;
                _writer.WriteLine($"{transactionAmount}.00 | {balance}.00");
            }
        }
    }
}