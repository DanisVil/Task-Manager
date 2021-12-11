using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDll;
using System.Threading;

namespace Study_guid_chapter_9
{
    class Program
    {
        static void Main(string[] args)
        {
            RUBBankAccount firstAccount = new RUBBankAccount(5000, BankAccount.Type.Current);
            EUBankAccount secondAccount = new EUBankAccount(200, BankAccount.Type.Current);
            firstAccount.PutMoney(200);
            Thread.Sleep(5000);
            firstAccount.WithdrawMoney(100);
            Thread.Sleep(3000);
            firstAccount.TransferMoney(secondAccount, 1000);
            firstAccount.Dispose();
            secondAccount.Dispose();

            Console.ReadKey();
        }
    }
}
