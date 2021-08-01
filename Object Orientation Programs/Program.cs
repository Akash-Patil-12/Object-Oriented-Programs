using Object_Orientation_Programs.Inventory_Management;
using System;

namespace Object_Orientation_Programs
{
    class Program
    {
         static void Main(string[] args)
        {
            //variables
            int userChoice;
            //Constants
            const string INVENTORY_JSON = @"H:\dot net\Object-Oriented-Programs\Object Orientation Programs\Inventory Management\InventoryJsonFile.json";
            const int ADD_RECORD = 1,EDIT_RECORD=2,DELETE_RECORD=3, SHOW_ALL_RECORDS = 4;
            InventoryMain inventoryMain = new InventoryMain();
            while (true)
            {
                Console.WriteLine("Press 1 : Add New Record");
                Console.WriteLine("Press 2 : Edit Record");
                Console.WriteLine("Press 3 : Delete Record");
                Console.WriteLine("Press 4 : Show All Record");
                Console.WriteLine("Enter your choice");
                userChoice = Convert.ToInt16(Console.ReadLine());
                switch (userChoice)
                {
                    case ADD_RECORD:
                        inventoryMain.AddRecord(INVENTORY_JSON);
                        break;
                    case EDIT_RECORD:
                        inventoryMain.EditRecord(INVENTORY_JSON);
                        break;
                    case DELETE_RECORD:
                        inventoryMain.DeleteRecord(INVENTORY_JSON);
                        break;
                    case SHOW_ALL_RECORDS:
                        inventoryMain.DisplayData(INVENTORY_JSON);
                        break;
                    default:
                        Console.WriteLine("Enter right choice");
                        break;
                }
                Console.WriteLine("Enter y to continue ohterwise press any key to terminate");
                char runOrStopProgram =char.ToLower(Convert.ToChar(Console.ReadLine()));
                if (runOrStopProgram != 'y')
                    break;
            }
        }
    }
}
