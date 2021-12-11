using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDll
{
    public class BankTransaction
    {
        readonly double money;
        readonly Currency currency;
        readonly DateTime dateTime;
        public BankTransaction(double money, Currency currency)
        {
            this.money = money;
            this.currency = currency;
            dateTime = DateTime.Now;
        }
        public double Money { get { return money; } }
        public Currency CurrentCurrency { get { return currency; } }
        public DateTime TransactionDateTime { get { return dateTime; } }
        public object this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return money;
                    case 1:
                        return currency;
                    case 2:
                        return dateTime;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        public override string ToString()
        {
            if (money < 0)
            {
                return $"Со счета было снято {-money} {currency.Name} {dateTime}";
            }
            else if (money > 0)
            {
                return $"На счет было начислено {money} {currency.Name} {dateTime}";
            }
            return "такого не должно было произойти";
        }
    }
}
