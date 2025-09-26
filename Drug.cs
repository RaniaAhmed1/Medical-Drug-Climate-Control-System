using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Drug_Climate_Control_System
{
    class Drug :AlertSystem
    {
        public string drugID;
        public string drugName;
        public DateTime expiryDate;
        public double requiredTemperature;
        public double requiredHumidity;
        public int quantity;
   
        public bool isExpired()
        {
            TimeSpan remaining = expiryDate - DateTime.Today;
            if (remaining.TotalDays <= 14)
                return true;
            else
                return false;

        }
        
        public void DisplayDrugInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Drug ID: " + drugID);
            Console.WriteLine("Drug Name: " + drugName);
            Console.WriteLine("Expiry Date: " + expiryDate.ToShortDateString());
            Console.WriteLine("Required Temperature: " + requiredTemperature + "°C");
            Console.WriteLine("Required Humidity: " + requiredHumidity + "%");
            Console.WriteLine("Drud Quantity: " + quantity);
        }
    }
}
