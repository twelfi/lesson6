namespace Task1;

public class Worker : EmployeeBase
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

    public double WorkedHours { get; set; }

    public override void GetDetails()
    {
        Console.WriteLine($"Информация о работнике:\n\tИмя: {Name},\n\tДолжность: {Position}, " +
            $"\n\tКоличество отработанных часов: {WorkedHours}");
    }
}
