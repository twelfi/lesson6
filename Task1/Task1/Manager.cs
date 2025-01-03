namespace Task1;

public class Manager : EmployeeBase
{
    private string _name;
    public override string Name
    {
        get { return _name; }
        set
        {
            while (string.IsNullOrWhiteSpace(value) || value.Any(char.IsDigit))
            {
                Console.WriteLine("Некорректное значение");
                value = Console.ReadLine();
            }
            _name = value;
        }
    }

    private string _position;
    public override string Position 
    { 
        get { return _position; }
        set
        {
            while (string.IsNullOrWhiteSpace(value) || value.Any(char.IsDigit))
            {
                Console.WriteLine("Некорректное значение");
                value = Console.ReadLine();
            }
            _position = value;
        }
    }

    public List<Project> Projects { get; set; } = new List<Project>();

    public override void GetDetails()
    {
        Console.WriteLine($"Информация о менеджере:\n\tИмя: {Name},\n\tДолжность: {Position},");
        Console.Write("\tПроекты менеджера: \n");

        if (Projects.Count > 0)
        {
            foreach (var project in Projects)
            {
                project.DisplayProjectInfo();
            }
        }
        else
        {
            Console.WriteLine("\tУ этого менеджера нет проектов.");
        }
    }

    public class Project
    {
        private string _projectName;
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                while (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Некорректное значение");
                    value = Console.ReadLine();
                }
                _projectName = value;
            }
        }

        public DateTime Deadline { get; set; }

        public void DisplayProjectInfo()
        {
            Console.WriteLine($"\tНазвание: {ProjectName}, Срок до: {Deadline.ToShortDateString()}");
        }
    }
}
