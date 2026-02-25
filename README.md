# 👨‍💼 Employee Data Management System

A robust and clean C# Console Application designed to manage employee records using flat-file storage. This project demonstrates core Object-Oriented Programming (OOP) principles, file I/O operations, and data manipulation techniques in .NET.

## ✨ Features

* **Store Data:** Overwrites existing data with new employee records safely.
* **Append Data:** Adds new employee records to the end of the existing dataset without data loss.
* **Retrieve & Sort:** Reads all records and displays them in ascending alphabetical order based on the First Name using LINQ.
* **Search:** Allows users to find specific employee records using a case-insensitive search by First Name.
* **Calculate Average:** Computes the average Gross Income of all stored employees, handling edge cases like empty files or invalid data.
* **Export to CSV:** Exports the entire dataset to the user's Desktop as a `.csv` file with proper headers, ready to be opened in Microsoft Excel or Power BI.

## 🛠️ Technologies & Concepts Used

* **Language:** C# (.NET)
* **Concepts:** Object-Oriented Programming (OOP), Exception Handling (`try-catch`), Input Validation, LINQ.
* **Data Storage:** Text-based flat file (`Persons.txt`), CSV Export formatting.

## 🚀 How to Run

1.  Clone this repository to your local machine.
2.  Open the project in Visual Studio.
3.  Run the application (`F5` or `Ctrl + F5`).
4.  Follow the interactive on-screen console menu to manage the data.

## 📁 Project Structure

* `Program.cs`: Contains the main application logic, console menu loop, and file handling methods.
* `Person.cs`: A dedicated data model class representing a single employee entity.

---
*Developed with clean code practices and a focus on software engineering fundamentals.*
