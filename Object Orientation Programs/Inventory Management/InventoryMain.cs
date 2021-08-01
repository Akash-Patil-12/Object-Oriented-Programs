using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Object_Orientation_Programs.Inventory_Management
{
    public class InventoryMain
    {
        //variables
        string checkInventoryName;
        //constants
        const int ADD_RICE = 1, ADD_PULSES = 2, ADD_WHEAT = 3;
        /// <summary>
        /// Display all records 
        /// </summary>
        /// <param name="filepath"></param>
        public void DisplayData(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string jsonData = File.ReadAllText(filepath);
                    InventoryFactory jsonObectArray = JsonConvert.DeserializeObject<InventoryFactory>(jsonData);
                    Console.WriteLine("Name\tWeight\tPricePerKg");
                    List<Rice> rice = jsonObectArray.RiceList;
                    foreach (var item in rice)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    }
                    List<Pulses> pulses = jsonObectArray.PulsesList;
                    foreach (var item in pulses)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    }
                    List<Wheat> wheat = jsonObectArray.WheatList;
                    foreach (var item in wheat)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    }                  
                }
                else
                {
                    Console.WriteLine("file not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Edit in record 
        /// </summary>
        /// <param name="filepath"></param>
        public void EditRecord(string filepath)
        {
            //variables
            bool checkRecord=false;
            if (File.Exists(filepath))
            {
                string jsonData = File.ReadAllText(filepath);
                InventoryFactory jsonObjectArray = JsonConvert.DeserializeObject<InventoryFactory>(jsonData);
                
                Console.WriteLine("Press 1 :  Rice List");
                Console.WriteLine("Press 2 :  Pulses List");
                Console.WriteLine("Press 3 :  Wheat List");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case ADD_RICE:
                        List<Rice> riceList = jsonObjectArray.RiceList;
                        Console.WriteLine("Enter the name which you want to edit");
                        checkInventoryName = Console.ReadLine();
                        foreach (Rice ricename in riceList)
                        {
                            if (ricename.Name.Equals(checkInventoryName))
                            {
                                Console.WriteLine("Enter Name");
                                ricename.Name = Console.ReadLine();
                                Console.WriteLine("Enter Weight");
                                ricename.Weight = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter PricePerKg");
                                ricename.PricePerKg = Convert.ToInt32(Console.ReadLine());
                                checkRecord = true;
                            }
                        }
                        if (checkRecord)
                            Console.WriteLine("Record Updated successfully......");
                        else
                            Console.WriteLine("Name does not found in Record...");
                        break;
                    case ADD_PULSES:
                        List<Pulses> pulsesList = jsonObjectArray.PulsesList;
                        Console.WriteLine("Enter name which you want to edit");
                        checkInventoryName = Console.ReadLine();
                        foreach (Pulses pulsesName in pulsesList)
                        {
                            if (pulsesName.Name.Equals(checkInventoryName))
                            {
                                Console.WriteLine("Enter Name");
                                pulsesName.Name = Console.ReadLine();
                                Console.WriteLine("Enter Weight");
                                pulsesName.Weight = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter PricePerKg");
                                pulsesName.PricePerKg = Convert.ToInt32(Console.ReadLine());
                                checkRecord = true;
                            }
                        }
                        if (checkRecord)
                            Console.WriteLine("Record Updated successfully......");
                        else
                            Console.WriteLine("Name does not found in Record...");
                        break;
                    case ADD_WHEAT:
                        List<Wheat> wheatList = jsonObjectArray.WheatList;
                        Console.WriteLine("Enter name which you want to edit");
                        checkInventoryName = Console.ReadLine();
                        foreach (Wheat wheatName in wheatList)
                        {
                            if (wheatName.Name.Equals(checkInventoryName))
                            {
                                Console.WriteLine("Enter Name");
                                wheatName.Name = Console.ReadLine();
                                Console.WriteLine("Enter Weight");
                                wheatName.Weight = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter PricePerKg");
                                wheatName.PricePerKg = Convert.ToInt32(Console.ReadLine());
                                checkRecord = true;
                            }
                        }
                        if (checkRecord == true)
                        {
                            string writeDataToFile = JsonConvert.SerializeObject(jsonObjectArray);
                            File.WriteAllText(filepath, writeDataToFile);
                            Console.WriteLine("Record Updated successfully......");
                        }
                        else
                            Console.WriteLine("Name does not found in Record...");
                        break;
                    default:
                        Console.WriteLine("Enter a right choice");
                        break;
                }              
            }
        }
        /// <summary>
        /// Delete specific record
        /// </summary>
        /// <param name="filepath"></param>
        public void DeleteRecord(string filepath)
        {
            bool checkRecord = true;
            if (File.Exists(filepath))
            {
                string jsonData = File.ReadAllText(filepath);
                InventoryFactory jsonObjectArray = JsonConvert.DeserializeObject<InventoryFactory>(jsonData);
                Console.WriteLine("Enter the name which you want to Delete");
                checkInventoryName = Console.ReadLine();
                List<Rice> riceList = jsonObjectArray.RiceList;
                foreach (Rice ricename in riceList)
                {
                    if (ricename.Name.Equals(checkInventoryName))
                    {
                        riceList.Remove(ricename);
                        checkRecord = false;
                        break;
                    }
                }
                if (checkRecord)
                {
                    List<Pulses> pulsesList = jsonObjectArray.PulsesList;
                    foreach (Pulses pulsesName in pulsesList)
                    {
                        if (pulsesName.Name.Equals(checkInventoryName))
                        {
                            pulsesList.Remove(pulsesName);
                            checkRecord = false;
                            break;
                        }
                    }
                }
                if (checkRecord)
                {
                    List<Wheat> wheatList = jsonObjectArray.WheatList;
                    foreach (Wheat wheatName in wheatList)
                    {
                        if (wheatName.Name.Equals(checkInventoryName))
                        {
                            wheatList.Remove(wheatName);
                            checkRecord = false;
                            break;
                        }
                    }
                }
                if (checkRecord == false)
                {
                    string writeDataToFile = JsonConvert.SerializeObject(jsonObjectArray);
                    File.WriteAllText(filepath, writeDataToFile);
                    Console.WriteLine("Record deleted successfully....");
                }
                else
                    Console.WriteLine("Record not found....");
            }
            else
            {
                Console.WriteLine("File does not present");
            }
        }
        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="filepath"></param>
        public void AddRecord(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string jsonData = File.ReadAllText(filepath);
                    InventoryFactory jsonObjectArray = JsonConvert.DeserializeObject<InventoryFactory>(jsonData);
                    Console.WriteLine("Press 1 : Add Rice List");
                    Console.WriteLine("Press 2 : Add Pulses List");
                    Console.WriteLine("Press 3 : Add Wheat List");
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case ADD_RICE:
                            List<Rice> riceList = jsonObjectArray.RiceList;
                            Rice rice = new Rice();
                            Console.WriteLine("Enter Name");
                            rice.Name = Console.ReadLine();
                            Console.WriteLine("Enter Weight");
                            rice.Weight =Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter PricePerKg");
                            rice.PricePerKg = Convert.ToInt32(Console.ReadLine()); 
                            riceList.Add(rice);
                            Console.WriteLine("Record added successfully.......");
                            break;
                        case ADD_PULSES:
                            List<Pulses> pulsesList = jsonObjectArray.PulsesList;
                            Pulses pulses = new Pulses();
                            Console.WriteLine("Enter Name");
                            pulses.Name = Console.ReadLine();
                            Console.WriteLine("Enter Weight");
                            pulses.Weight = Convert.ToInt32(Console.ReadLine()); 
                            Console.WriteLine("Enter PricePerKg");
                            pulses.PricePerKg =Convert.ToInt32(Console.ReadLine()); 
                            pulsesList.Add(pulses);
                            Console.WriteLine("Record added successfully.......");
                            break;
                        case ADD_WHEAT:
                            List<Wheat> wheatList = jsonObjectArray.WheatList;
                            Wheat wheat = new Wheat();
                            Console.WriteLine("Enter Name");
                            wheat.Name = Console.ReadLine();
                            Console.WriteLine("Enter Weight");
                            wheat.Weight = Convert.ToInt32(Console.ReadLine()); 
                            Console.WriteLine("Enter PricePerKg");
                            wheat.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            wheatList.Add(wheat);
                            Console.WriteLine("Record added successfully.......");
                            break;
                        default:
                            Console.WriteLine("Enter a right choice");
                            break;
                    }
                    string writeDataToFile = JsonConvert.SerializeObject(jsonObjectArray);
                    File.WriteAllText(filepath, writeDataToFile);
                }
                else
                    Console.WriteLine("File does not exit");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
