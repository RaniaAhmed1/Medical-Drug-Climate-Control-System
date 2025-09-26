using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Drug_Climate_Control_System
{
    class DrugsManagement : Drug
    {
        string filePath = @"C:\Users\PC\source\repos\Medical Drug Climate Control System\bin\Debug\drugs.txt";
        ValidateInput validateInput = new ValidateInput();
       
        public void AddDrug()             // add new drug to the system
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Drug newDrug = new Drug();
            Console.Write("Enter Drug ID: ");
            newDrug.drugID =validateInput.ValidateString(Console.ReadLine());
            Console.Write("Enter Drug Name: ");
            newDrug.drugName = validateInput.ValidateString(Console.ReadLine());
            Console.Write("Enter Expiry Date (yyyy-MM-dd): ");
            newDrug.expiryDate= validateInput.ValidateDate(Console.ReadLine());
            Console.Write("Enter Required Temperature (°C): ");
            newDrug.requiredTemperature = validateInput.ValidateDouble(Console.ReadLine(), -30, 30);
            Console.Write("Enter Required Humidity (%): ");
            newDrug.requiredHumidity = validateInput.ValidateDouble(Console.ReadLine(), 0, 100);
            Console.Write("Enter Quantity: ");
            newDrug.quantity = validateInput.ValidateInt(Console.ReadLine(), 1, int.MaxValue);


            string[] lines =File.ReadAllLines(filePath);        // to check if drug with same ID already exists
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] == newDrug.drugID)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Drug with this ID already exists!");
                    return;
                }
            }
            using (StreamWriter sw = File.AppendText(filePath))    // append new drug to the file
            {
                sw.WriteLine($"{newDrug.drugID},{newDrug.drugName},{newDrug.expiryDate.ToString("yyyy-MM-dd")},{newDrug.requiredTemperature},{newDrug.requiredHumidity},{newDrug.quantity}");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Drug is successfully added to the system!");
        }

        //***************************************************************************************************************
        public void UpdateDrug()                     // update drug info
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Drug exsist = new Drug();
            int indexOfUpdatedDrug = -1;
            Console.Write("Enter drug Id to update information: ");
            exsist.drugID = validateInput.ValidateString(Console.ReadLine());

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts1 = lines[i].Split(',');
                if (parts1[0] == exsist.drugID)
                {
                    exsist.drugID = parts1[0];
                    exsist.drugName = parts1[1];
                    exsist.expiryDate = DateTime.Parse(parts1[2]);
                    exsist.requiredTemperature = double.Parse(parts1[3]);
                    exsist.requiredHumidity = double.Parse(parts1[4]);
                    exsist.quantity = int.Parse(parts1[5]);
                    exsist.DisplayDrugInfo();
                    indexOfUpdatedDrug = i;
                    break;
                }
            }

            if (indexOfUpdatedDrug == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Drug ID not found. Update cancelled!");
                return;
            }
             
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter updated data: ");
                Console.Write("Expiry Date: ");
                exsist.expiryDate = validateInput.ValidateDate(Console.ReadLine());
                Console.Write("Drug Quantity: ");
                exsist.quantity = validateInput.ValidateInt(Console.ReadLine(), 1, int.MaxValue);
                Console.Write("\nIf you sure about these updates ,enter 1 or any number otherwise: ");
                string input = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(input, out int choice) && choice == 1)
                {
                    string[] parts2 = lines[indexOfUpdatedDrug].Split(',');
                    parts2[2] = exsist.expiryDate.ToString("yyyy-MM-dd");
                    parts2[5] = exsist.quantity.ToString();

                    lines[indexOfUpdatedDrug] = string.Join(",", parts2);
                    File.WriteAllLines(filePath, lines);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Drug information is successfully updated!");
                    break;
                }
                else if (int.TryParse(input, out choice) && choice != 1)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Invalid input!\nplease enter a valid number 1 to accept or other to cancel: ");
                    input = Console.ReadLine();
                }
            }
        }

        //*****************************************************************************************************

        public void SearchForDrug()                // search for drug by ID or name
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Drug currentDrug = new Drug();
            Console.Write("Enter drug ID/name to search for: ");
            string input = validateInput.ValidateString(Console.ReadLine());      // can be ID or string

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts[0] == input || parts[1] == input) 
                {
                    currentDrug.drugID = parts[0];
                    currentDrug.drugName = parts[1];
                    currentDrug.expiryDate = DateTime.Parse(parts[2]);
                    currentDrug.requiredTemperature = double.Parse(parts[3]);
                    currentDrug.requiredHumidity = double.Parse(parts[4]);
                    currentDrug.quantity = int.Parse(parts[5]);
                    currentDrug.DisplayDrugInfo();
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("This drug does not exist in the system!");
        }


        //*****************************************************************************************************


        public void RemoveDrug()               // delete drug from the system
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Drug exsist = new Drug();
            int indexOfDeletedDrug = -1;
            Console.Write("Enter drug Id to delete: ");
            exsist.drugID = validateInput.ValidateString(Console.ReadLine());

            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            for (int i = 0; i < lines.Count; i++)         // to find the drug to be deleted
            {
                string[] parts1 = lines[i].Split(',');
                if (parts1[0] == exsist.drugID)
                {
                    exsist.drugID = parts1[0];
                    exsist.drugName = parts1[1];
                    exsist.expiryDate = DateTime.Parse(parts1[2]);
                    exsist.requiredTemperature = double.Parse(parts1[3]);
                    exsist.requiredHumidity = double.Parse(parts1[4]);
                    exsist.quantity = int.Parse(parts1[5]);
                    exsist.DisplayDrugInfo();
                    indexOfDeletedDrug = i;
                    break;
                }
            }
            if(indexOfDeletedDrug == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This drug does not exist in the system!");
                return;
            }

            Console.Write("\nIf you sure you want to delete that drug, enter 1 or any number otherwise: ");
            string input = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(input, out int choice) && choice == 1)
                {
                    lines.RemoveAt(indexOfDeletedDrug);
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("Drug is successfully daleted!");
                    break;
                }
                else if (int.TryParse(input, out choice) && choice != 1)
                    break;
                else
                {
                    Console.Write("Invalid input!\nplease enter a valid number 1 to accept or other to cancel: ");
                    input = Console.ReadLine();
                }
            }
        }


        //***************************************************************************************************************



        public void CheckExpiryStatus()         // check for expired drugs
        {
            List<Drug> expiredDrugs = new List<Drug>();
            List<Drug> unsafeConditions = new List<Drug>();

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                Drug drug = new Drug();
                drug.drugID = parts[0];
                drug.drugName = parts[1];
                drug.expiryDate = DateTime.Parse(parts[2]);
                drug.requiredTemperature = double.Parse(parts[3]);
                drug.requiredHumidity = double.Parse(parts[4]);
                drug.quantity = int.Parse(parts[5]);
                if (drug.isExpired())
                   expiredDrugs.Add(drug);
            }
            Console.WriteLine("   --- Expired Drugs (less than 14 days to expire) ---\n");
            if (expiredDrugs.Count == 0)
            {
                Console.WriteLine("\t\tNo expired drugs!");
                return;
            }
            Console.WriteLine($"Drug ID\t\tDrug Name\t\tDays Left To Expire\n");
            foreach (var drug in expiredDrugs)
            {
                Console.WriteLine($"{drug.drugID}\t\t{drug.drugName}\t\t\t{drug.expiryDate-DateTime.Today}");
            }
        }



        //*******************************************************************************************************************


        public void GenerateReport()       // generate report of low stock drugs , in stock drugs and expired drugs
        {
            List<Drug> lowStock = new List<Drug>();
            List<Drug> instock = new List<Drug>();

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                Drug drug = new Drug();
                drug.drugID = parts[0];
                drug.drugName = parts[1];
                drug.expiryDate = DateTime.Parse(parts[2]);
                drug.requiredTemperature = double.Parse(parts[3]);
                drug.requiredHumidity = double.Parse(parts[4]);
                drug.quantity = int.Parse(parts[5]);
                if (drug.quantity<=20)
                    lowStock.Add(drug);
                else
                    instock.Add(drug);
            }

            if(lowStock.Count == 0)
            {
                Console.WriteLine("\n--- Low Stock Drugs ---");
                Console.WriteLine("  No low stock drugs!");
            }
            else
            {
                Console.WriteLine("\n\t   --- Low Stock Drugs ---\n");               //report of low stock drugs
                Console.WriteLine($"Drug ID\t\tDrug Name\t\tQuantity\n");
                foreach (var drug in lowStock)
                {
                    Console.WriteLine($"{drug.drugID}\t\t{drug.drugName}\t\t\t{drug.quantity}");
                }
            }
            Console.WriteLine("\n==================================================================");
            if (instock.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("\n\t   --- In Stock Drugs ---\n");             // report of in stock drugs
                Console.WriteLine($"Drug ID\t\tDrug Name\t\tQuantity\n");
                foreach (var drug in instock)
                {
                    Console.WriteLine($"{drug.drugID}\t\t{drug.drugName}\t\t\t{drug.quantity}");
                }
            }
            else
            {
                Console.WriteLine("\n--- In Stock Drugs ---");
                Console.WriteLine("  No in stock drugs!");
            }

            Console.WriteLine("\n==================================================================");
            Console.WriteLine();
            CheckExpiryStatus();              // report of expired drugs
        }


        //**********************************************************************************************************


        public void checkConditions()          // check current conditions for a specific drug
        {
            AlertSystem alertSystem = new AlertSystem();
            TemperatureSensor sensor = new TemperatureSensor();
            Drug currentDrug = new Drug();
            Console.Write("Enter drug ID/name to check conditions: ");
            string input = validateInput.ValidateString(Console.ReadLine());      // can be ID or string
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts[0] == input || parts[1] == input)
                {
                    currentDrug.drugID = parts[0];
                    currentDrug.drugName = parts[1];
                    currentDrug.expiryDate = DateTime.Parse(parts[2]);
                    currentDrug.requiredTemperature = double.Parse(parts[3]);
                    currentDrug.requiredHumidity = double.Parse(parts[4]);
                    currentDrug.quantity = int.Parse(parts[5]);
                }
            }
            if (currentDrug.drugID == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This drug does not exist in the system!");
                return;
            }
            Console.Write("Enter current Temperature (°C): ");
            alertSystem.ReadTemperature(validateInput.ValidateDouble(Console.ReadLine(), -50, 50));
            Console.Write("Enter current Humidity (%): ");
            alertSystem.ReadHumidity(validateInput.ValidateDouble(Console.ReadLine(), 0, 100));
            Console.WriteLine();
            alertSystem.CheckConditions(currentDrug);
        }
    }
}
