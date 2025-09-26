using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Drug_Climate_Control_System
{
    class Employee
    {
        public string EmployeeID;
        public string Name;
        public string Role;
        string filePath = @"C:\\Users\\PC\\source\\repos\\Medical Drug Climate Control System\\bin\\Debug\\employeeInfo.txt";

        public Employee(string id, string name, string role)
        {
            EmployeeID = id;
            Name = name;
            Role = role;
        }

        public string FormatForFile()
        {
            return $"{EmployeeID},{Name},{Role}|";
        }


        public void LogAction(string action)             // log employee actions to a file
        {
            var allLines = File.Exists(filePath) ? File.ReadAllLines(filePath).ToList() : new List<string>();
            bool updated = false;

            for (int i = 0; i < allLines.Count; i++)
            {
                if (allLines[i].StartsWith($"{EmployeeID},"))
                {
                    // Update existing line
                    var parts = allLines[i].Split('|');
                    var existingActions = parts.Length > 1 ? parts[1].Split(',').ToList() : new List<string>();
                    existingActions.Add(action);
                    allLines[i] = $"{EmployeeID},{Name},{Role}|{string.Join(",", existingActions)}";
                    updated = true;
                    break;
                }
            }

            File.WriteAllLines(filePath, allLines);
        }



    }
}
