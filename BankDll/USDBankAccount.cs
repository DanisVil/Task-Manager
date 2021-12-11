namespace BankDll
{
    public class USDBankAccount : BankAccount
    {
        public USDBankAccount(double balance, Type type)
        {
            this.balance = balance;
            this.type = type;
            Currency usdollar = new Currency("US dollar", 1);
            SetCurrency(usdollar);
        }
    }
}