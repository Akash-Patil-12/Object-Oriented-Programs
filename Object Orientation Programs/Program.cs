using Object_Orientation_Programs.Inventory_Management;
using Object_Orientation_Programs.Stock_Management;
using System;

namespace Object_Orientation_Programs
{
    class Program
    {
         static void Main(string[] args)
         {
            //variables
            int userChoice=0;
            double amount;
            string symbol;
            //constants
            const string FILE_CUSTOMER = @"H:\dot net\Object-Oriented-Programs\Object Orientation Programs\Stock Management\CustomerInformation.json";
            const int SHOW_ALLCUSTOMER = 1, ADD_NEW_ACCOUNT = 2, VALUE_OF_ACCOUNT = 3, BUY = 4,SELL=5,PRINT_REPORT=6,EXIT=7;
            StockAccount stockAccount = new StockAccount();
            while (userChoice!=7)
            {
                Console.WriteLine("Press 1 : Show All Account List");
                Console.WriteLine("Press 2 : Add New Account");
                Console.WriteLine("Press 3 : Get Value of Account in Doller");
                Console.WriteLine("Press 4 : Buy a Share");
                Console.WriteLine("Press 5 : Sell a Share");
                Console.WriteLine("Press 6 : PrintReport");
                Console.WriteLine("Press 7 : Exit");
                Console.WriteLine("Enter your choice");
                userChoice = Convert.ToInt16(Console.ReadLine());
                switch (userChoice)
                {
                    case SHOW_ALLCUSTOMER:
                        stockAccount.AllCustomer(FILE_CUSTOMER);
                        break;
                    case ADD_NEW_ACCOUNT:
                        stockAccount.AddNewAccount(FILE_CUSTOMER);
                        break;
                    case VALUE_OF_ACCOUNT:
                        string customerName;
                        Console.WriteLine("Enter the name of customer to show total amount");
                        customerName = Console.ReadLine();
                        amount = stockAccount.ShowTotalValueOfAccount(customerName);
                        if (amount < 0)
                            Console.WriteLine("Account name does not exit");
                        else
                            Console.WriteLine("Account Amount is $ :" + amount / 70);
                        break;
                    case BUY:
                        Console.WriteLine("Enter a amount");
                        amount = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter a symbol");
                        symbol = Console.ReadLine();
                        stockAccount.Buy(amount,symbol);
                        break;
                    case SELL:
                        Console.WriteLine("Enter a amount");
                        amount = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter a symbol");
                        symbol = Console.ReadLine();
                        stockAccount.Sell(amount,symbol);
                        break;
                    case PRINT_REPORT:
                        stockAccount.PrintReport();
                        break;
                    case EXIT:
                        userChoice = 7;
                        break;
                    default:
                        Console.WriteLine("You have entered wrong choice");
                        break;
                }
            }            
         }
    }
}
