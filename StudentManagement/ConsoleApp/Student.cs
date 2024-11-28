namespace ConsoleApp;

public class Student
{
  public ushort ID { get; private set; }
  public string Name { get; private set; }
  public ushort FirstMark { get; private set; }
  public ushort SecondMark { get; private set; }
  public decimal Average { get => (FirstMark + SecondMark) / 2; }

  public Grade Grade
  {
    get
    {
      if (Average < 60)
      {
        return Grade.Failed;
      }
      if (Average >= 60 && Average < 70)
      {
        return Grade.Good;
      }
      if (Average >= 70 && Average < 90)
      {
        return Grade.VeryGood;
      }
      return Grade.Excellent;
    }
  }

  public Student(ushort id, string name, ushort firstMark, ushort secondMark)
  {
    ID = id;
    Name = name;
    FirstMark = firstMark;
    SecondMark = secondMark;
  }

  public override string ToString()
  {
    return $"{{ 'id': '{ID}', 'name': '{Name}',  'average': {Average}, 'grade': {Grade} }}";
  }
}
