using Object_Orientation_Programs.Inventory_Management;
using System;

namespace Object_Orientation_Programs
{
    class Program
    {
        const string INVENTORY_JSON = @"H:\dot net\Object Orientation Programs\Inventory Management\InventoryJsonFile.json";
        static void Main(string[] args)
        {
            InventoryMain inventoryMain = new InventoryMain();
            inventoryMain.DisplayData(INVENTORY_JSON);
        }
    }
}
