using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDataManager
{
    class program
    {

        static string fileName = "Persons.txt";
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n===========================");
                Console.WriteLine("1- Store the input data");
                Console.WriteLine("2- Append New record");
                Console.WriteLine("3- Retrieve the content in ascending order");
                Console.WriteLine("4- Search for specific record");
                Console.WriteLine("5- Calculate the average of gross income");
                Console.WriteLine("6- Export Data to Desktop (CSV)");
                Console.WriteLine("7- Exit");
                Console.WriteLine("===========================");
                Console.Write("Enter your choice: ");

                String choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("--> Here we will store data.");
                        StoreData();
                        break;
                    case "2":
                        Console.WriteLine("--> Here we will append a record.");
                        AppendData();
                        break;
                    case "3":
                        Console.WriteLine("--> Here we will retrieve and sort.");
                        RetrieveData();
                        break;
                    case "4":
                        Console.WriteLine("--> Here we will search.");
                        SearchData();
                        break;
                    case "5":
                        Console.WriteLine("--> Here we will calculate average.");
                        CalculateAverageIncome();
                        break;
                    case "6":
                        Console.WriteLine("--> Here we will export data.");
                        ExportData();
                        break;
                    case "7":
                        isRunning = false;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        static void StoreData()
        {
            Console.WriteLine("\n--- Store New Data ---");

            Console.WriteLine(" WARNING: This will DELETE all existing data! Are you sure? (Y/N)");
            string answer = Console.ReadLine();

            if (answer.ToLower() != "y")
            {
                Console.WriteLine("Operation cancelled. Returning to main menu...");
                return;
            }

            Person p = new Person();
            Console.Write("Enter First Name: ");
            p.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            p.LastName = Console.ReadLine();

            Console.Write("Enter Gross Income: ");
            double validIncome;

            while (!double.TryParse(Console.ReadLine(), out validIncome) || validIncome < 0)
            {

                Console.WriteLine("Invalid input! Please enter a valid number.");
                Console.Write("Enter Gross Income again: ");
            }
            p.GrossIncome = validIncome;

            Console.Write("Enter Marital Status: ");
            p.MaritalStatus = Console.ReadLine();

            string record = $"{p.FirstName},{p.LastName},{p.GrossIncome},{p.MaritalStatus}";

            try
            {
                File.WriteAllText(fileName, record + Environment.NewLine);
                Console.WriteLine("Data stored successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error storing data: {ex.Message}");
            }
        }


        static void AppendData()
        {
            Console.WriteLine("\n--- Append New Record ---");

            Person p = new Person();

            Console.Write("Enter First Name: ");
            p.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            p.LastName = Console.ReadLine();

            Console.Write("Enter Gross Income: ");

            double validIncome;

            while (!double.TryParse(Console.ReadLine(), out validIncome) || validIncome < 0)
            {

                Console.WriteLine("Invalid input! Please enter a valid number.");
                Console.Write("Enter Gross Income again: ");
            }
            p.GrossIncome = validIncome;

            Console.Write("Enter Marital Status: ");
            p.MaritalStatus = Console.ReadLine();

            string record = $"{p.FirstName},{p.LastName},{p.GrossIncome},{p.MaritalStatus}";

            try
            {
                File.AppendAllText(fileName, record + Environment.NewLine);
                Console.WriteLine("Record appended successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending record: {ex.Message}");
            }

        }

        static void RetrieveData()
        {
            Console.WriteLine("\n--- Retrieve Data (Ascending Order) ---");
            if (!File.Exists(fileName))
            {
                Console.WriteLine("No data found! Please store some data first.");
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            List<Person> peopleList = new List<Person>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4)
                {
                    Person p = new Person();
                    p.FirstName = parts[0];
                    p.LastName = parts[1];
                    p.GrossIncome = Convert.ToDouble(parts[2]);
                    p.MaritalStatus = parts[3];
                    peopleList.Add(p);
                }
            }
            var sortedList = peopleList.OrderBy(p => p.FirstName).ToList();

            Console.WriteLine("\n[ Sorted Records ]");

            foreach (var item in sortedList)
            {
                Console.WriteLine($"Name: {item.FirstName} {item.LastName} | Income: {item.GrossIncome} | Status: {item.MaritalStatus}");
            }
        }

        static void SearchData()
        {
            Console.WriteLine("\n--- Search for a Record ---");

            if (!File.Exists(fileName))
            {
                Console.WriteLine(" No data found! The file might be deleted or not created yet.");
                return;
            }
            Console.Write("Enter the First Name to search for: ");
            string targetName = Console.ReadLine().ToLower();
            string[] lines = File.ReadAllLines(fileName);
            bool isFound = false;

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4)
                {
                    if (parts[0].ToLower() == targetName)
                    {
                        Console.WriteLine("\n [ Record Found ]");
                        Console.WriteLine($"Name: {parts[0]} {parts[1]} | Income: {parts[2]} | Status: {parts[3]}");
                        isFound = true;
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("\n No record found with this name.");
            }

        }

        static void CalculateAverageIncome()
        {
            Console.WriteLine("\n--- Calculate Average Gross Income ---");
            if (!File.Exists(fileName))
            {
                Console.WriteLine(" No data found! The file might be deleted or not created yet.");
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty. No data to calculate.");
                return;
            }

            double totalIncome = 0;
            int count = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4)
                {
                    if (double.TryParse(parts[2], out double income))
                    {
                        totalIncome += income;
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                double average = totalIncome / count;
                Console.WriteLine($"\n Total Employees: {count}");

                Console.WriteLine($" Average Gross Income: {average:F2}");
            }
            else
            {
                Console.WriteLine("\n No valid income data found to calculate.");
            }

        }


        static void ExportData()
        {
            Console.WriteLine("\n--- Export Data to Desktop ---");

            if (!File.Exists(fileName))
            {
                Console.WriteLine("No data found to export! Please store some data first.");
                return;
            }

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string exportFilePath = Path.Combine(desktopPath, "Persons.csv");
                string header = "FirstName,LastName,GrossIncome,MaritalStatus";
                string existingData = File.ReadAllText(fileName);
                string finalContent = header + Environment.NewLine + existingData;
                File.WriteAllText(exportFilePath, finalContent);

                Console.WriteLine("File successfully exported to your Desktop!");
                Console.WriteLine($"Path: {exportFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting data: {ex.Message}");
            }
        }
    }
}