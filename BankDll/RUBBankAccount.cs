namespace BankDll
{
    public class RUBBankAccount : BankAccount
    {
        public RUBBankAccount(double balance, Type type)
        {
            this.balance = balance;
            this.type = type;
            Currency ruble = new Currency("Ruble", 0.013);
            SetCurrency(ruble);
        }
    }
}