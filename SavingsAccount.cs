using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsApp
{
    class SavingsAccount : Account
    {
        // Fields
        private const double TRANSACTION_FEE = 3.50;

        // Properties
        public double Interest { get; set; }

        public SavingsAccount(int number, string name, double balance, double interest) : base (number, name, balance)
        {
            Interest = interest;
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
