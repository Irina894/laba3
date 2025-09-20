using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

class Employee
{
    public string Name;
    public double Salary;
    public string Position;
    public string Department;
    public string Email;
    public int Age;

    public Employee(string name, double salary, string position, string department)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = "n/a"; 
        Age = -1;   
    }

    public Employee(string name, double salary, string position, string department, string email, int age)
        : this(name, salary, position, department)
    {
        Email = email;
        Age = age;
    }

    public void Show()
    {
        Console.WriteLine($"{Name} {Salary:F2} {Email} {Age}");
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter n of employees:");
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        Console.WriteLine("Enter name salary position department email age:");
        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = parts[0];
            double salary = double.Parse(parts[1]);
            string position = parts[2];
            string department = parts[3];

            if (parts.Length == 4)
            {
                employees.Add(new Employee(name, salary, position, department));
            }
            else if (parts.Length == 5)
            {
                string email = parts[4];
                employees.Add(new Employee(name, salary, position, department, email, -1));
            }
            else if (parts.Length == 6)
            {
                string email = parts[4];
                int age = int.Parse(parts[5]);
                employees.Add(new Employee(name, salary, position, department, email, age));
            }
        }

        // 1. знайдемо всі відділи
        List<string> departments = new List<string>();
       for(int i=0; i<employees.Count; i++)
        {
            if (!departments.Contains(employees[i].Department))
            {
                departments.Add(employees[i].Department);
            }
        }
     
        // 2. шукаємо відділ з найбільшою середньою зарплатою
        string bestDepartment = "";
        double bestAverage = 0;

        for (int i=0; i<departments.Count; i++)
        {  
            string dept = departments[i];
            double totalSalary = 0;
            int count = 0;
            for (int j = 0; j < employees.Count; j++)
            {
                if (employees[j].Department == dept)
                {
                    totalSalary += employees[j].Salary;
                    count++;
                }
            }
            double averageSalary = totalSalary / count;
            if (averageSalary > bestAverage)
            {
                bestAverage = averageSalary;
                bestDepartment = dept;
            }
        }
       
        Console.WriteLine("Highest Average Salary: " + bestDepartment);

        for (int i = 0; i < employees.Count - 1; i++)
        {
            for (int j = i + 1; j < employees.Count; j++)
            {
                if (employees[i].Salary < employees[j].Salary)
                {
                    Employee temp = employees[i];
                    employees[i] = employees[j];
                    employees[j] = temp;
                }
            }
        }

        for (int i = 0; i < employees.Count; i++)
        {
            if (employees[i].Department == bestDepartment)
            {
                employees[i].Show();
            }
        }
    }
}
