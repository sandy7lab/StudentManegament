namespace ConsoleApp;

class Program
{
    static string[] options = { "Add student", "Delete student", "Display all students", "Exit" };
    static StudentLinkedList students = new StudentLinkedList();
    static string resetColor = "\x1b[0m";
    static string successColor = "\x1b[32m";
    static string infoColor = "\x1b[33m";
    static string errorColor = "\x1b[31m";

    static void Main()
    {
    A: Options.title = "Student Management";
     var option = Options.Display(options);
        switch (option)
        {
            case 0:
                AddStudent();
                break;
            case 1:
                DeleteStudent();
                break;
            case 2:
                DisplayStudents();
                break;
            default:
                Exit();
                break;
        }
        goto A;
    }

    static void AddStudent()
    {
        Console.WriteLine($"{infoColor}Enter student name{resetColor}");
        var name = Console.ReadLine();
        Console.Clear();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine($"{errorColor}Invalid name!{resetColor}");
            Console.ReadKey(true);
            Console.Clear();
            AddStudent();
        }
        var firstMark = ValidateMark(true);
        var secondMark = ValidateMark(false);
        students.Insert(name ?? "", firstMark, secondMark);
        Console.WriteLine($"{successColor}Student added successfully!{resetColor}");
        Console.ReadKey(true);
    }

    static void DeleteStudent()
    {
        Console.WriteLine($"{infoColor}Enter student id{resetColor}");
        if (!ushort.TryParse(Console.ReadLine(), out var id))
        {
            Console.Clear();
            Console.WriteLine($"{errorColor}Invalid id!{resetColor}");
            Console.ReadKey(true);
            Console.Clear();
            DeleteStudent();
        }
        if (students.Delete(id))
        {
            Console.WriteLine($"{successColor}Student deleted successfully!{resetColor}");
            Console.ReadKey(true);
            Console.Clear();
            return;
        }
        Console.WriteLine($"{errorColor}Student not found!{resetColor}");
        Console.ReadKey(true);
        Console.Clear();
    }

    static void DisplayStudents()
    {
        students.Display();
        Console.ReadKey(true);
    }

    static void Exit()
    {
        Console.WriteLine($"{successColor}Thank you for using my software.{resetColor}");
        Console.ReadKey(true);
        Console.Clear();
        Environment.Exit(0);
    }

    static ushort ValidateMark(bool isFirst)
    {
        string str = isFirst ? "first" : "second";
        Console.WriteLine($"{infoColor}Enter {str} mark for student{resetColor}");
        if (!ushort.TryParse(Console.ReadLine(), out var mark))
        {
            Console.Clear();
            Console.WriteLine($"{errorColor}Invalid {str} mark!{resetColor}");
            Console.ReadKey(true);
            Console.Clear();
            ValidateMark(isFirst);
        }
        if (mark < 0 || mark > 100)
        {
            Console.Clear();
            Console.WriteLine($"{errorColor}Invalid {str} mark!{resetColor}");
            Console.ReadKey(true);
            Console.Clear();
            ValidateMark(isFirst);
        }
        Console.Clear();
        return mark;
    }
}
