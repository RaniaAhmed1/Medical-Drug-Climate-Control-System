using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Drug_Climate_Control_System
{
    class ValidateInput
    {
        public int ValidateInt(string input, int min, int max)   // validating integer input
        {
            bool notValidInput = true;
            int value;
            do
            {
                if (int.TryParse(input, out  value) && value >= min && value <= max)
                {
                    notValidInput = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input!");
                    Console.Write("Please enter a valid number: ");
                    input = Console.ReadLine();
                }

            } while (notValidInput);

            Console.ForegroundColor = ConsoleColor.Magenta;
            return value;
        }

        public double ValidateDouble(string input, double min, double max)   // validating double input
        {
            bool notValidInput = true;
            double value;
            do
            {
                if (double.TryParse(input, out value) && value >= min && value <= max)
                {
                    notValidInput = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input!");
                    Console.Write("Please enter a valid number: ");
                    input = Console.ReadLine();
                }
            } while (notValidInput);
            Console.ForegroundColor = ConsoleColor.Magenta;
            return value;
        }


        public string ValidateString(string input)   // validating string input
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input!");
                Console.Write("Please enter a valid string: ");
                input = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            return input;
        }

        public DateTime ValidateDate(string input)  // validating date input
        {
            DateTime dateValue;
            while (!DateTime.TryParse(input, out dateValue) || dateValue < DateTime.Today)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid date input!");
                Console.Write("Please enter a valid date (yyyy-MM-dd): ");
                input = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            return dateValue;
        }

    }
}
