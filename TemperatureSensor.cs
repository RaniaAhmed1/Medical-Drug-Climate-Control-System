using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Drug_Climate_Control_System
{
    class TemperatureSensor
    {
       public double currentTemperature;
       public double currentHumidity;

        public void ReadTemperature(double currentTemprature)
        {
            this.currentTemperature = currentTemprature;
        }
        public void ReadHumidity(double currentHumidity)
        {
            this.currentHumidity = currentHumidity;
        }
        public void DisplayReadings() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The current temprature: {currentTemperature}");
            Console.WriteLine($"The current humidity: {currentHumidity}");
        }

    }
}
