namespace Medical_Drug_Climate_Control_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValidateInput validateInput = new ValidateInput();
           
            Employee emp1 = new Employee("E001", "Rania Salem", "Pharmacist");
            Employee emp2 = new Employee("E002", "Youssef Adel", "Doctor");
            Employee emp3 = new Employee("E003", "Mariam Fathy", "Admin");
            Employee emp4 = new Employee("E004", "Omar Nabil", "Pharmacist");
            Employee emp5 = new Employee("E005", "Laila Hassan", "Doctor");

            List<Employee> employees = new List<Employee> { emp1, emp2, emp3, emp4, emp5 };

            List<string> linesToWrite = new List<string>();

            foreach (var emp in employees)
            {
                linesToWrite.Add(emp.FormatForFile());
            }
            File.WriteAllLines(@"C:\\Users\\PC\\source\\repos\\Medical Drug Climate Control System\\bin\\Debug\\employeeInfo.txt", linesToWrite);



            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t\t--- Medical Drug Climate Control System ---\n\n");

          
           
                Employee currentEmployee = null;
                Console.WriteLine("Enter your data: ");
                while (currentEmployee == null)              // make sure that employee entered valid data
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Enter your ID: ");
                    string ID = Console.ReadLine();
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter your role: ");
                    string role = Console.ReadLine();


                    for (int i = 0; i < employees.Count; i++)
                    {
                        if (employees[i].EmployeeID == ID && employees[i].Name == name && employees[i].Role == role)
                        {
                            currentEmployee = employees[i];
                            Console.WriteLine("Logged in successfully!");
                            break;
                        }
                    }
                   

                    if (currentEmployee == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid data!\nYou can't enter!\n\nTry to enter a valid data: ");
                    }
                }

                string filePath = @"C:\Users\PC\source\repos\Medical Drug Climate Control System\bin\Debug\drugs.txt";   
                

            int choice = -1;
            while (choice != 9)
            {

                //   Display menu options
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n1. Add Drug\n2. Update Drug Information\n3. Search Drug\n4. Remove Drug\n5. Check Expiry Status\n6. Check Conditions For a Drug\n7. Generate Report\n8. View Log File\n9. Exit System\n\n");
                Console.Write("Enter your choice: ");
                choice = validateInput.ValidateInt(Console.ReadLine(), 1, 9);

                DrugsManagement drugsManagement = new DrugsManagement();
                Logger logger = new Logger();



                if (choice ==1 && (currentEmployee.Role=="Pharmacist" || currentEmployee.Role == "Admin")) // only pharmacist and admin can add drugs
                {
                    drugsManagement.AddDrug();
                    currentEmployee.LogAction("Added a drug");
                    logger.AddLog($"{currentEmployee.Name} added a drug.");
                }



                else if (choice == 2 && (currentEmployee.Role == "Pharmacist" || currentEmployee.Role == "Admin")) // only pharmacist and admin can update drugs
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool noDrugs = false;
                    if (lines.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No drugs available in the system!\nYou need to add drugs first.\n");  // making sure that the system has drugs
                        noDrugs = true;
                        continue;
                    }
                    drugsManagement.UpdateDrug();
                    currentEmployee.LogAction("Updated a drug information");
                    logger.AddLog($"{currentEmployee.Name} updated a drug information.");
                }



                else if (choice == 3 && (currentEmployee.Role == "Pharmacist" || currentEmployee.Role == "Admin" || currentEmployee.Role=="Doctor")) // all employees can search for drugs
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool noDrugs = false;
                    if (lines.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No drugs available in the system!\nYou need to add drugs first.\n");  // making sure that the system has drugs
                        noDrugs = true;
                        continue;
                    }
                    drugsManagement.SearchForDrug();
                    currentEmployee.LogAction("Searched for a drug");
                    logger.AddLog($"{currentEmployee.Name} searched for a drug.");
                }



                else if (choice == 4 && (currentEmployee.Role == "Pharmacist" || currentEmployee.Role == "Admin"))  // only pharmacist and admin can remove drugs
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool noDrugs = false;
                    if (lines.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No drugs available in the system!\nYou need to add drugs first.\n");  // making sure that the system has drugs
                        noDrugs = true;
                        continue;
                    }
                    drugsManagement.RemoveDrug();
                    currentEmployee.LogAction("Removed a drug");
                    logger.AddLog($"{currentEmployee.Name} removed a drug.");
                }



                else if (choice == 5 && (currentEmployee.Role == "Pharmacist" || currentEmployee.Role == "Admin"))  // only pharmacist and admin can check expiry status
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool noDrugs = false;
                    if (lines.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No drugs available in the system!\nYou need to add drugs first.\n");  // making sure that the system has drugs
                        noDrugs = true;
                        continue;
                    }
                    drugsManagement.CheckExpiryStatus();
                    currentEmployee.LogAction("Checked expiry status of a drug");
                    logger.AddLog($"{currentEmployee.Name} checked expiry status of a drug.");
                }



                else if (choice == 6 && (currentEmployee.Role == "Pharmacist" || currentEmployee.Role == "Admin")) // only pharmacist and admin can check conditions
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool noDrugs = false;
                    if (lines.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No drugs available in the system!\nYou need to add drugs first.\n");  // making sure that the system has drugs
                        noDrugs = true;
                        continue;
                    }
                    drugsManagement.checkConditions();
                    currentEmployee.LogAction("Checked conditions for a drug");
                    logger.AddLog($"{currentEmployee.Name} checked conditions for a drug.");
                }



                else if (choice == 7 && (currentEmployee.Role == "Pharmacist" || currentEmployee.Role == "Admin")) // only pharmacist and admin can generate report
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool noDrugs = false;
                    if (lines.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No drugs available in the system!\nYou need to add drugs first.\n");  // making sure that the system has drugs
                        noDrugs = true;
                        continue;
                    }
                    drugsManagement.GenerateReport();
                    currentEmployee.LogAction("Generated report");
                    logger.AddLog($"{currentEmployee.Name} generated report.");   
                }



                else if (choice == 8 && currentEmployee.Role == "Admin")  // only admin can view log file
                {
                    logger.DisplayLogs();
                    currentEmployee.LogAction("Viewed log file");
                    logger.AddLog($"{currentEmployee.Name} viewed log file.");
                }



                else if (choice == 9 && (currentEmployee.Role == "Pharmacist" || currentEmployee.Role == "Admin" || currentEmployee.Role == "Doctor")) // all employees can exit the system
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Exiting program successfully!");
                    return;
                }



                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You can't do this operation!");
                }
                  
               
            }

        }
    }
}
