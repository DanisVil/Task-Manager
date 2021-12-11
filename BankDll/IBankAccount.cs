using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDll
{
    public interface IBankAccount
    {
        void PutMoney(double money);
        double WithdrawMoney(double money);
        void TransferMoney(IBankAccount recipeint, double money);
    }
}
