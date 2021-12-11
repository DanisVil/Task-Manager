using System.Collections.Generic;

namespace BankDll
{
    public class BankAccountFactory
    {
        private Dictionary<ushort, BankAccount> heshTable = new Dictionary<ushort, BankAccount>();
        public BankAccount CreateAccount(string name, double money, BankAccount.Type type)
        {
            switch (name)
            {
                case "рубль":
                    RUBBankAccount ruble = new RUBBankAccount(money, type);
                    heshTable.Add(ruble.ID, ruble);
                    return ruble;
                case "доллар":
                    USDBankAccount dollar = new USDBankAccount(money, type);
                    heshTable.Add(dollar.ID, dollar);
                    return dollar;
                case "евро":
                    EUBankAccount euro = new EUBankAccount(money, type);
                    heshTable.Add(euro.ID, euro);
                    return euro;
                default:
                    ruble = new RUBBankAccount(money, type);
                    heshTable.Add(ruble.ID, ruble);
                    return ruble;
            }
        }
        public void RemoveAccount(ushort id)
        {
            heshTable.Remove(id);
        }
    }
}