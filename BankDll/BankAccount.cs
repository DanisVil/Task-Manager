using System;
using System.Collections.Generic;
using System.IO;

namespace BankDll
{
    public class BankAccount: IBankAccount
    {
        public enum Type { Current = 1, Saving = 2 };
        protected static float bonus;
        private static ushort counter = 1;
        protected ushort id = counter;
        protected double balance = 0;
        protected Type type;
        protected Currency currency;
        protected string Owner { get; private set; }
        private Queue<BankTransaction> checks = new Queue<BankTransaction>();
        protected void SetCurrency(Currency currency)
        {
            this.currency = currency;
        }
        public void PutMoney(double money)
        {
            if (money > 0)
            {
                balance += money;
                checks.Enqueue(new BankTransaction(money, currency));
            }
        }
        public double WithdrawMoney(double money)
        {
            if (money < balance && money > 0)
            {
                balance -= money;
                checks.Enqueue(new BankTransaction(-money, currency));
                if (type.Equals(Type.Saving))
                {
                    return money * (1 + balance);
                }
                return money;
            }
            Console.WriteLine("-Какими деньгами?");
            return 0;
        }
        public Type AccountType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public ushort ID
        {
            get
            {
                return id;
            }
        }
        public BankAccount(double balance, Type type)
        {
            this.balance = balance;
            this.type = type;
            counter++;
        }
        internal BankAccount()
        {
            counter++;
        }

        public string Info
        {
            get
            {
                string str_type = ((int)type).Equals(1) ? "текущий" : "сберегательный";
                return $"Номер счёта: {id}\nБаланс: {balance}\nТип: {str_type}\nВалюта: {currency.Name}";
            }
        }

        public void TransferMoney(IBankAccount recipeint, double money)
        {
            BankAccount reflection = recipeint as BankAccount;
            if (reflection != null)
            {
                if (balance >= money && money > 0)
                {
                    balance -= money;
                    reflection.balance += currency.Compare(reflection.currency) * money;
                    checks.Enqueue(new BankTransaction(-money, currency));
                    reflection.checks.Enqueue(new BankTransaction(currency.Compare(reflection.currency) * money, 
                        reflection.currency));
                }
                else
                {
                    Console.WriteLine("Недостаточно средств для выполнения перевода");
                }
            }
        }
        public void Dispose()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"Account{ID}report.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine();
                    while (checks.Count != 0)
                    {
                        sw.WriteLine(checks.Dequeue());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            GC.SuppressFinalize(this);
        }
        public static bool operator ==(BankAccount first, BankAccount second)
        {
            if (first is null && !(second is null) || !(first is null) && second is null)
            {
                return false;
            }
            if (first.ID == second.ID)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(BankAccount first, BankAccount second)
        {
            return !(first == second);
        }
        public override bool Equals(object obj)
        {
            BankAccount bankAccount = obj as BankAccount;
            if (bankAccount is null)
            {
                return false;
            }
            if (bankAccount.ID.Equals(ID))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
        public override string ToString()
        {
            return $"id счета - {id}\nбаланс - {balance} {currency.Name}\nтип - {type}";
        }
    }
}