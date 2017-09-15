namespace Bank
{
    public interface BankAccount {
        void Deposit(int amount);
        void Withdraw(int amount);
        void PrintStatement();
    }
}
