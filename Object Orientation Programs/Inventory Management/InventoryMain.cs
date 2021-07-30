using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Object_Orientation_Programs.Inventory_Management
{
    public class InventoryMain
    {
        public void DisplayData(string filepath)
        {
            try
            {
                using (StreamReader read = new StreamReader(filepath))
                {
                    var json = read.ReadToEnd();

                    var items = JsonConvert.DeserializeObject<List<InventoryModel>>(json);
                    Console.WriteLine("Name\tWeight\tRate");
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

    }
}
