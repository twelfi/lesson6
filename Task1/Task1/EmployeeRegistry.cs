namespace Task1;

public static class EmployeeRegistry
{
    public static List<EmployeeBase> employees = new List<EmployeeBase>();

    public static void AddEmployee(EmployeeBase employee)
    {
        Console.WriteLine("Кого вы хотите добавить: если менеджера - M, если работника - W");
        while (true)
        {
            var type = Console.ReadLine().ToUpper();
            switch (type)
            {
                case "M":
                    Console.WriteLine("Вы добавляете менеджера.");
                    Manager newM = new Manager();

                    Console.WriteLine("Введите имя менеджера:");
                    newM.Name = Console.ReadLine();

                    Console.WriteLine("Введите должность менеджера:");
                    newM.Position = Console.ReadLine();

                    Console.WriteLine("Ведет ли этот менеджер какой-то проект. Да - Y, Нет - N.");
                    while (true)
                    {
                        var haveproj = Console.ReadLine().ToUpper();
                        switch(haveproj)
                        {
                            case "Y":
                                Console.WriteLine("У менеджера есть проект. Добавьте больше информации о проекте:");
                                Manager.Project newP = new Manager.Project();

                                Console.WriteLine("Введите название проекта:");
                                newP.ProjectName = Console.ReadLine();

                                Console.WriteLine("Какой дедлайн? Дату необходимо ввести в формате ГГГГ-ММ-ДД");
                                DateTime projectDeadline;
                                while (!DateTime.TryParse(Console.ReadLine(), out projectDeadline) || projectDeadline < DateTime.Now)
                                {
                                    Console.WriteLine("Некорректная дата, попробуйте снова");
                                }

                                newM.Projects.Add(newP);
                                Console.WriteLine("Менеджер добавлен. Вот добавленная инфорамция:");
                                EmployeeRegistry.employees.Add(newM);
                                newM.GetDetails();
                                return;
                            case "N":
                                Console.WriteLine("У данного менеджера сейчас нет проектов");
                                EmployeeRegistry.employees.Add(newM);
                                Console.WriteLine("Менеджер добавлен. Вот доавленная информация:");
                                newM.GetDetails();
                                return;
                            default:
                                Console.WriteLine("Необходимо ввести Y или N");
                                break;
                        }
                    }

                case "W":
                    Console.WriteLine("Вы добавляете работника.");
                    Worker newW = new Worker();

                    Console.WriteLine("Введите имя работника:");
                    newW.Name = Console.ReadLine();

                    Console.WriteLine("Введите должность работника:");
                    newW.Position = Console.ReadLine();

                    Console.WriteLine("Введите количество отработанных часов:");
                    double _workedHours;
                    while (!double.TryParse(Console.ReadLine(), out _workedHours) || _workedHours < 0)
                    {
                        Console.WriteLine("Некорректное значение");
                    }
                    newW.WorkedHours = _workedHours;

                    EmployeeRegistry.employees.Add(newW);
                    Console.WriteLine("Работник добавлен. Вот добавленная информация:");
                    newW.GetDetails();
                    return;
                default:
                    Console.WriteLine("Необходимо ввести M или W");
                    break;
            }
        }
    }
    public static void ListAllEmployees()
    {
        Console.WriteLine("Информация про всех сотрудников:");
        var totalEmployees = EmployeeRegistry.employees.Count;
        Console.WriteLine($"Общее количество: {totalEmployees}");

        foreach (var employee in EmployeeRegistry.employees)
        {
            employee.GetDetails();
        }
    }

    public static void FindEmployee()
    {
        Console.WriteLine("Введите имя сотрудника для поиска:");
        string name = Console.ReadLine();

        bool found = false;

        foreach (var employee in EmployeeRegistry.employees)
        {
            if (employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                employee.GetDetails();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Сотрудник с таким именем не найден");
        }
    }

}
