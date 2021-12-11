namespace BankDll
{
    public class EUBankAccount : BankAccount
    {
        public EUBankAccount(double balance, Type type)
        {
            this.balance = balance;
            this.type = type;
            Currency euro = new Currency("Euro", 1.12);
            SetCurrency(euro);
        }
    }
}