using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsApp
{
    class CheckingAccount : Account
    {
        // Fields
        private const double TRANSACTION_FEE = 2.00;

        // Properties
        public double Limit { get; set; }

        public CheckingAccount(int number, string name, double balance, double limit) : base (number, name, balance)
        {
            Limit = limit;
        }

        // Concrete method that overrides Account methods
        public override void Deposit(double amount)
        {
            this.Balance += amount - TRANSACTION_FEE;
        }

        public override void Withdraw(double amount)
        {
            this.Balance -= amount - TRANSACTION_FEE;
        }
    }
}
