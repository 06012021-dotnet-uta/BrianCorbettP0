using System;

namespace BusinessLayer
{
  public class Write : IWrite
  {
    public void PutLine(string message)
    {
      Console.WriteLine(message);
    }
  }
}