using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetReflectionApp
{
    public class BankAccount
    {
        double amount = 0;

        public BankAccount(double amount)
        {
            this.amount = amount;
        }

        public BankAccount() : this(0) { }
        public double GetAmount() => amount;

        public void AddAmount(in double amount)
        {
            this.amount += amount;
        }

        public void AddPercent(double percent = 1)
        {
            this.amount += (this.amount * percent);
        }
    }
}
