namespace ConsoleApp;

public static class Options
{
  public static string? title;
  private static ConsoleKey _key;
  private static int _option = 0;
  private static string _resetColor = "\x1b[0m";
  private static string _cyanColor = "\x1b[36m";
  private static string _blueColor = "\x1b[34m";

  public static int Display(string[] options)
  {
    Console.Clear();
    do
    {
      if (!string.IsNullOrWhiteSpace(title))
      {
        WriteTitle(title);
      }
      for (int i = 0; i < options.Length; i++)
      {
        if (_option == i)
        {
          Console.WriteLine($"{_cyanColor}>> {options[i]}{_resetColor}");
          continue;
        }
        Console.WriteLine($"   {options[i]}");
      }
      _key = Console.ReadKey(true).Key;
      if (_key == ConsoleKey.DownArrow && _option < options.Length - 1)
      {
        _option++;
      }
      if (_key == ConsoleKey.UpArrow && _option > 0)
      {
        _option--;
      }
      Console.Clear();
    } while (_key != ConsoleKey.Enter);
    return _option;
  }

  private static void WriteTitle(string title)
  {
    Console.WriteLine(_blueColor + "   " + new string('-', title.Length + 4));
    Console.WriteLine($"   | {title} |");
    Console.WriteLine("   " + new string('-', title.Length + 4) + _resetColor + "\n");
  }
}
