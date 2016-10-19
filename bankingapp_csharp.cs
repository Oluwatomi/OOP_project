using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banking_Application
{
    /// <summary>
    /// This is an abstract class. You cannot create an instance of this class. This class can only be used as a base class.
    /// </summary>
    public abstract class Account
    {
        /// <summary>
        /// balance can only be accessed in a derived class
        /// </summary>
        protected decimal balance;
        
        /// <summary>
        /// Initializes a new instance of the Account class
        /// </summary>
        public Account()
        {
            balance = 0;
        }

        /// <summary>
        /// Initializes a new instance of the Account class with one argument
        /// </summary>
        /// <param name="bal">Account balance</param>
        public Account(decimal bal)
        {
            balance = bal;
        }

        /// <summary>
        /// This Property returns the Account balance. The property is read only.
        /// </summary>
        public virtual decimal Balance
        {
            get { return balance; }
        }

        /// <summary>
        /// This is a withdraw method. The method is virtual and must be overriden in a derived class.
        /// </summary>
        /// <param name="amount">The amount to be withdrawn from the account balance.</param>
        public virtual void Withdraw(decimal amount)
        {
                balance -= amount;
        }

        /// <summary>
        /// This is a Deposit method. 
        /// </summary>
        /// <param name="amount">The amount to be added to the account balance.</param>
        public virtual void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

    }

    /// <summary>
    /// SavingsAccount Inherits from the Account class.
    /// </summary>
    public class SavingsAccount : Account
    {
        /// <summary>
        /// Initializes a new instance of the SavingsAccount class
        /// </summary>
        public SavingsAccount()
        {
            balance = 0;
        }

        /// <summary>
        /// Initializes a new instance of the SavingsAccount class with one argument
        /// </summary>
        /// <param name="b">Account balance</param>
        public SavingsAccount(decimal b) :
            base(b)
        {
        }

        /// <summary>
        /// This is a withdraw method. It allows withdrawal up to #0.00
        /// </summary>
        /// <param name="amount">The amount to be withdrawn from the account balance.</param>
        public override void Withdraw(decimal amount)
        {
            if (amount < balance)
                balance -= amount;
            else
                Console.WriteLine("Insufficient Funds");
        }

        /// <summary>
        /// Savings Account Deposit Method
        /// </summary>
        /// <param name="amount">Amount</param>
        public override void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

    }

    /// <summary>
    ///  CurrentsAccount Inherits from the Account class.
    /// </summary>
    public class CurrentsAccount : Account 
    {
        private decimal overdraw = -10000;

        /// <summary>
        /// Initializes a new instance of the SavingsAccount class
        /// </summary>
        public CurrentsAccount()
        {
            balance = 0;
        }

        /// <summary>
        /// Initializes a new instance of the CurrentsAccount class with one argument
        /// </summary>
        /// <param name="b">Account Balance</param>
        public CurrentsAccount(decimal b):
        base(b) {
        }

        /// <summary>
        /// This is a withdraw method. It allows withdrawal up to #-10000.00
        /// </summary>
        /// <param name="amount">The amount to be withdrawn from the account balance.</param>
        public override void Withdraw(decimal amount)
        {
            if ((balance - amount) >= overdraw)
                balance -= amount;
            else
                Console.WriteLine("Insufficient Funds");
        }

        /// <summary>
        /// Current Account Deposit Method
        /// </summary>
        /// <param name="amount">Amount</param>

        public override void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

    }
}