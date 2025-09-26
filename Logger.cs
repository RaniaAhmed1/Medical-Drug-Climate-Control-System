using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Drug_Climate_Control_System
{
    class Logger
    {
        List<string> Logs= new List<string>();
        string logFilePath = @"C:\Users\PC\source\repos\Medical Drug Climate Control System\bin\Debug\logs.txt";


        public void AddLog(string log)                 // write to logs file
        {
            Logs.Add(log);
            string timestampedLog = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {log}";
            File.AppendAllText(logFilePath, timestampedLog + Environment.NewLine);
        }


        public void DisplayLogs()               // read from logs file
        {
            string[] logs = File.ReadAllLines(logFilePath);
            if (File.Exists(logFilePath) && logs.Length!=0)
            {
                foreach (string log in logs)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(log);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No logs yet!");
            }

        }
    }
}
