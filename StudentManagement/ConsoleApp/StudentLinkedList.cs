namespace ConsoleApp;

public class StudentLinkedList
{
  public StudentNode? First { get; private set; }
  public int Count { get; private set; }
  private ushort _studentID = 0;

  public StudentLinkedList() => Count = 0;

  public void Insert(string name, ushort firstMark, ushort secondMark)
  {
    var newNode = new StudentNode(CreateStudent(name, firstMark, secondMark));

    if (First == null || First.Data.Average > newNode.Data.Average)
    {
      newNode.Next = First;
      First = newNode;
    }
    else
    {
      var move = First;
      while (move.Next != null && move.Next.Data.Average < newNode.Data.Average)
      {
        move = move.Next;
      }
      newNode.Next = move.Next;
      move.Next = newNode;
    }
    Count++;
    _studentID++;
  }

  public bool Delete(ushort id)
  {
    if (First == null)
    {
      return false;
    }
    if (First.Data.ID == id)
    {
      First = First.Next;
      Count--;
      return true;
    }
    var move = First;
    while (move.Next != null && move.Next.Data.ID != id)
    {
      move = move.Next;
    }
    if (move.Next == null)
    {
      return false;
    }
    move.Next = move.Next.Next;
    Count--;
    return true;
  }

  public void Display()
  {
    var move = First;
    while (move != null)
    {
      Console.WriteLine(move.Data);
      move = move.Next;
    }
  }

  private Student CreateStudent(string name, ushort firstMark, ushort secondMark) => new Student(_studentID, name, firstMark, secondMark);
}
