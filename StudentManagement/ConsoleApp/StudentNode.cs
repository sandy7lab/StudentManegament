namespace ConsoleApp;

public class StudentNode
{
  public Student Data { get; set; }
  public StudentNode? Next { get; set; }

  public StudentNode(Student value)
  {
    Data = value;
  }
}
