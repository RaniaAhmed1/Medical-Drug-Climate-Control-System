using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Drug_Climate_Control_System
{
    class AlertSystem : TemperatureSensor
    {
        bool IsAlertActive = false;

       public void CheckConditions(Drug drug)
       {
            if ((Math.Abs(currentTemperature - drug.requiredTemperature) <= 5) && (Math.Abs(currentHumidity - drug.requiredHumidity) <= 5))
            {
                IsAlertActive = false;
            }
            else
            {
                IsAlertActive = true;
            }
            SendAlert(IsAlertActive);
        }

        public void SendAlert(bool isAlertActive)
        {
            if (IsAlertActive)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("ALERT! The current conditions are out of the required range for the drug.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The current conditions are within the required range for the drug.");
            }
            ResetAlert();
        }
        public void ResetAlert()
        {
            IsAlertActive = false;
           
        }


    }
}
