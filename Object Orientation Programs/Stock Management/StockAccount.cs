using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Object_Orientation_Programs.Stock_Management
{
    class StockAccount
    {
        const string FILE_CUSTOMER = @"H:\dot net\Object-Oriented-Programs\Object Orientation Programs\Stock Management\CustomerInformation.json";
        const string STOCKLIST_FILE = @"H:\dot net\Object-Oriented-Programs\Object Orientation Programs\Stock Management\StocksList.json";

        /// <summary>
        /// Show all account list
        /// </summary>
        /// <param name="filepath"></param>
        public void AllCustomer(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string allDataFile = File.ReadAllText(filepath);
                    List<CustomerModel> customerModels = JsonConvert.DeserializeObject<List<CustomerModel>>(allDataFile);
                    Console.WriteLine("Name\tSymbol\tShares\tTotalAmount\tDate Time");
                    foreach(CustomerModel customerData in customerModels)
                    {
                        Console.WriteLine(customerData.Name + "\t" + customerData.Symbol + "\t" + customerData.NumberOfShares + "\t" + customerData.Amount + "\t" + customerData.DateTime);
                    }
                }
                else
                {
                    Console.WriteLine("File does not exits");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Add new Account
        /// </summary>
        /// <param name="filepath"></param>
        public void AddNewAccount(string filepath)
        {
            if (File.Exists(filepath)){
                string allDataFile = File.ReadAllText(filepath);
                List<CustomerModel> customerModels = JsonConvert.DeserializeObject<List<CustomerModel>>(allDataFile);
                CustomerModel customerModel = new CustomerModel();
                Console.WriteLine("Enter Customer Name");
                customerModel.Name = Console.ReadLine();
                customerModel.NumberOfShares = 0;
                Console.WriteLine("Enter Amount");
                customerModel.Amount =Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter a Symbol");
                customerModel.Symbol = Console.ReadLine();
                DateTime dateTime = DateTime.Now;
                customerModel.DateTime = dateTime;
                customerModels.Add(customerModel);
                File.WriteAllText(filepath, JsonConvert.SerializeObject(customerModels));
                Console.WriteLine("New Account Created Successfully.....");
            }
            else
            {
                Console.WriteLine("file does not exits");
            }
        }
        public double ShowTotalValueOfAccount(string customerName)
        {
            bool checkCustomer = false;
            double returnAmount = 0;

            List<CustomerModel> customerModels = JsonConvert.DeserializeObject<List<CustomerModel>>(File.ReadAllText(FILE_CUSTOMER));
            foreach(CustomerModel customers in customerModels)
            {
                if (customers.Name.Equals(customerName))
                {
                    checkCustomer = true;
                    returnAmount = customers.Amount;
                    break;
                }
            }
            if (checkCustomer == false)
            {
                returnAmount = -1;
            }
            return returnAmount;
        }
        public void Sell(double amount,string symbol)
        {
            bool checkSymbol = false, checkStock = false;
            StockPortfolio stockPortfolio = new StockPortfolio();
            stockPortfolio.ShowAllStock(STOCKLIST_FILE);
            Console.WriteLine("Which share do you want to sell");
            string shareName = Console.ReadLine();
            List<StockModel> stockList = JsonConvert.DeserializeObject<List<StockModel>>(File.ReadAllText(STOCKLIST_FILE));
            foreach (StockModel allStocks in stockList)
            {
                if (allStocks.StockName.Equals(shareName))
                {
                    double sellShares = (amount / allStocks.SharePrice);
                    List<CustomerModel> customerList = JsonConvert.DeserializeObject<List<CustomerModel>>(File.ReadAllText(FILE_CUSTOMER));
                    foreach (CustomerModel customers in customerList)
                    {
                        if (customers.Symbol.Equals(symbol))
                        {
                            if (customers.NumberOfShares >= sellShares)
                            {
                                customers.Amount += amount;
                                customers.NumberOfShares -= sellShares;
                                DateTime dateTime = DateTime.Now;
                                customers.DateTime = dateTime;
                                File.WriteAllText(FILE_CUSTOMER, JsonConvert.SerializeObject(customerList));
                                allStocks.NumberOfShare += sellShares;
                                File.WriteAllText(STOCKLIST_FILE, JsonConvert.SerializeObject(stockList));
                                Console.WriteLine("sell of Stock is successfull.....");
                                checkSymbol = true;
                                break;
                            }
                            else
                            {
                                checkSymbol = true;
                                Console.WriteLine("Customer does not contains this number of share :" + sellShares);
                                break;
                            }
                           
                        }
                    }
                    checkStock = true;
                }
            }
            if (checkSymbol == false)
                Console.WriteLine("Customer does not contains this Symbol");
            if (checkStock == false)
                Console.WriteLine("This stock are not available");
        }
        public void Buy(double amount,string symbol)
           {
            double noOfShare;
            string shareName;
            bool checkBuy = false,checkSharename=false;
            StockPortfolio stockPortfolio = new StockPortfolio();
            stockPortfolio.ShowAllStock(STOCKLIST_FILE);
            List<StockModel> stockList = JsonConvert.DeserializeObject<List<StockModel>>(File.ReadAllText(STOCKLIST_FILE));
            Console.WriteLine("Enter the name of share which do you want to buy");
            shareName = Console.ReadLine();
            foreach(StockModel allStocks in stockList)
            {
                if (allStocks.StockName.Equals(shareName))
                {
                    noOfShare = amount / allStocks.SharePrice; 
                    if (allStocks.NumberOfShare >= noOfShare)
                    {
                        Console.WriteLine("Share buy=" + noOfShare);
                        allStocks.NumberOfShare = allStocks.NumberOfShare - noOfShare;
                        Console.WriteLine(noOfShare + "Share Buy successfully......");
                        File.WriteAllText(STOCKLIST_FILE, JsonConvert.SerializeObject(stockList));
                        List<CustomerModel> customerList = JsonConvert.DeserializeObject<List<CustomerModel>>(File.ReadAllText(FILE_CUSTOMER));
                        foreach(CustomerModel customers in customerList)
                        {
                            if (customers.Symbol.Equals(symbol))
                            {
                                DateTime dateTime = DateTime.Now;
                                customers.NumberOfShares = customers.NumberOfShares+noOfShare;
                                customers.Amount =customers.Amount-amount;
                                customers.DateTime = dateTime;
                                File.WriteAllText(FILE_CUSTOMER, JsonConvert.SerializeObject(customerList));
                                Console.WriteLine("Customer Information also updated..");
                                break;
                            }                         
                        }
                        checkBuy = true;
                    }
                    checkSharename = true;
                    break;
                }
            }
            if (checkSharename == false)
                Console.WriteLine(shareName + " share not available");
            if (checkBuy == false)
                Console.WriteLine("This amount of shares not available");
        }
        public void PrintReport()
        {
            Console.WriteLine("Detail Report of stock are listed below :");
            StockPortfolio stockPortfolio = new StockPortfolio();
            stockPortfolio.ShowAllStock(STOCKLIST_FILE);
        }

    }
}
