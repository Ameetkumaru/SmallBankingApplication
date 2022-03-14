using System;

namespace SimpleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account("Tom", 1000, AccountType.checking);
            Account acc2 = new Account("Mary", 1000, AccountType.Individual);

            acc1.Deposit(200);
            acc1.PrintBankInformation();

            acc1.WithdrawalConfirmation(300);
            acc1.PrintBankInformation();

            acc2.transferConfirmation(acc1, acc2, 250);
            acc1.PrintBankInformation();
            acc2.PrintBankInformation();

        }
    }
}
