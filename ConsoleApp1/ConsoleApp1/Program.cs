using System;
using System.Collections.Generic;

// Базовый класс сотрудника
public class Employee
{
    public string Name { get; set; }
    public decimal BaseSalary { get; set; }

    public Employee(string name, decimal baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }

    // Виртуальный метод расчета зарплаты
    public virtual decimal CalculateMonthlySalary()
    {
        return BaseSalary;
    }
}

// Класс Менеджер
public class Manager : Employee
{
    public decimal Bonus { get; set; }

    public Manager(string name, decimal baseSalary, decimal bonus)
        : base(name, baseSalary)
    {
        Bonus = bonus;
    }

    public override decimal CalculateMonthlySalary()
    {
        return BaseSalary + Bonus;
    }
}

// Класс Разработчик
public class Developer : Employee
{
    public int LinesOfCodeWritten { get; set; }

    public Developer(string name, decimal baseSalary, int linesOfCodeWritten)
        : base(name, baseSalary)
    {
        LinesOfCodeWritten = linesOfCodeWritten;
    }

    public override decimal CalculateMonthlySalary()
    {
        decimal bonusPerLine = 0.25m; // премия за строку кода
        return BaseSalary + (LinesOfCodeWritten * bonusPerLine);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Расчет заработной платы ---");

        // Полиморфный список сотрудников
        List<Employee> employees = new List<Employee>
        {
            new Manager("Менеджер Иван Петров", 100000m, 5000m),
            new Developer("Разработчик Анна Сидорова", 90000m, 2100),
            new Manager("Менеджер Олег Васильев", 120000m, 10000m)
        };

        // Полиморфный вызов метода
        foreach (Employee employee in employees)
        {
            Console.WriteLine(
                $"Зарплата для {employee.Name}: {employee.CalculateMonthlySalary():0}"
            );
        }

        Console.WriteLine("\nНажмите Enter для завершения...");
        Console.ReadLine();
    }
}
