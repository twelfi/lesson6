using System.ComponentModel;

namespace Task1;
internal class Program
{
    static void Main(string[] args)
    {
        Manager manager1 = new Manager
        {
            Name = "Лера",
            Position = "Старший менеджер"
        };

        Manager manager2 = new Manager
        {
            Name = "Саша",
            Position = "Младший менеджер"
        };

        Manager manager3 = new Manager
        {
            Name = "Алиса",
            Position = "Менеджер-стажер"
        };

        Manager.Project project1 = new Manager.Project
        {
            ProjectName = "Проект 1",
            Deadline = new DateTime(2025, 8, 11)
        };

        Manager.Project project2 = new Manager.Project
        {
            ProjectName = "Проект 2",
            Deadline = new DateTime(2025, 4, 23)
        };

        Manager.Project project3 = new Manager.Project
        {
            ProjectName = "Проект 3",
            Deadline = new DateTime(2025, 10, 13)
        };

        manager1.Projects.Add(project1);
        manager1.Projects.Add(project2);
        manager2.Projects.Add(project3);

        EmployeeRegistry.employees.Add(manager1);
        EmployeeRegistry.employees.Add(manager2);
        EmployeeRegistry.employees.Add(manager3);

        Worker worker1 = new Worker
        {
            Name = "Антон",
            Position = "Программист",
            WorkedHours = 32.5
        };
        EmployeeRegistry.employees.Add(worker1);

        EmployeeRegistry.AddEmployee(new Manager());

        EmployeeRegistry.ListAllEmployees();

        EmployeeRegistry.FindEmployee();
    }
}
