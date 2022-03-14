using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBank
{
    public class Transaction
    {

        
    }
    
    public class Account
    {
        string customerName = String.Empty;        
        
        long accountNumber ;

        double balance = 0.0;

        AccountType accountType; 

        public Account(string own, double bal, AccountType account)
        {
            customerName = own;
            balance = bal;
            accountNumber = GenerateAccountNumber();
            accountType = account;
        }

        public string CustomerName { get { return customerName; } set { customerName = value; } }

        public double Balance { get { return balance; } set { balance = value; } }

        public long AccountNumber { get { return accountNumber; } }

        public AccountType AccountTypes { get { return accountType; } }


        /// <summary>
        /// Using Random, we are generating account Number
        /// </summary>
        /// <returns></returns>
        public long GenerateAccountNumber()
        {
            Random rand = new Random();
            return rand.Next(10000, 99999999); //for ints
        }


        /// <summary>
        /// Deposit method is used to add the amount to the account balance.
        /// </summary>
        /// <param name="amountDeposit"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public void Deposit(double amountDeposit)
        {
            Balance = Balance + amountDeposit;
        }

        /// <summary>
        /// Withdraw method is used to remove money from the account balance
        /// </summary>
        /// <param name="withdraw"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public int Withdraw(double withdrawAmount)
        {
            if (Balance < 0) // Doesn't have any money in account
                return -1;
            if (Balance < withdrawAmount) // Doesn't have sufficient balance
                return -2;
            else if (AccountTypes == AccountType.Individual && withdrawAmount > 500) // Individual account withdrawal limit of $500
                return -3;
            else
            {
                Balance = Balance - withdrawAmount;
                return 0;
            }
            
        }

        /// <summary>
        /// Transfer method is used to transfer balance from one account to other
        /// </summary>
        /// <param name="amountDeposit"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public int Transfer(Account from, Account to, double balance)
        {
            if (from.AccountTypes == to.AccountTypes) // Same account
                return -4;
            else
            {
                if (from.Balance < balance) //Doesn't have sufficient balance
                    return -2;
                else
                {
                    from.Balance = from.Balance - balance;
                    to.Balance = to.Balance + balance;

                    return 0; // success
                }
            }
        }

        /// <summary>
        /// function to call Withdraw method
        /// </summary>
        /// <param name="withdrawAmount"></param>
        public void WithdrawalConfirmation(double withdrawAmount)
        {
            int code = Withdraw(withdrawAmount);

            Console.WriteLine(ErrorMessage(code));
        }

        /// <summary>
        /// Function to call Tranfer function
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="balance"></param>
        public void transferConfirmation(Account from, Account to, double balance)
        {
            int code = Transfer(from, to, balance);

            Console.WriteLine(ErrorMessage(code));
        }

        /// <summary>
        /// Print the Customer Information
        /// </summary>
        public void PrintBankInformation()
        {
            Console.WriteLine("Welcome " + CustomerName + ".Your account number is " + AccountNumber + " and your balance is $" + Balance);
        }


        /// <summary>
        /// Method to print the error message
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string ErrorMessage(int code)
        {
            switch(code)
            {
                case -1:
                    return "Doesn't have money in account";                    
                case -2:
                    return "Doesn't have sufficient balance";                    
                case -3:
                    return "Individual account withdrawal limit of $500";                    
                case -4:
                    return "Same account. Cannot transfer to and from same account";                    
                case 0:
                    return "Transaction successful";
                default:
                    return "";
            }
        }

    }



    /// <summary>
    /// We can use enum to distinguish Account type
    /// </summary>
    public enum AccountType
    {
        checking = 1,

        // Individual and Corporate are Investment Account
        Individual = 2,

        Corporate = 3
    }
}
