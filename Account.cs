using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsApp
{
    abstract class Account
    {
        // Properties
        public int Number { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }

        // Account constructor
        public Account(int number, string name, double balance)
        {
            Number = number;
            Name = name;
            Balance = balance;
        }

        // Crearting Abstract Methods to be used by child classes
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
    }
}
