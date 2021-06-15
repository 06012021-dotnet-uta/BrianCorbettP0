namespace BusinessLayer
{
  public class UserInteract : IWrite, IRead
  {
    readonly Write write = new();
    readonly Read read = new();

    public void PutLine(string message)
    {
      write.PutLine(message);
    }

    public int GetInteger(string prompt = "=> ")
    {
      return read.GetInteger(prompt);
    }
    public string GetString(string prompt="=> ")
    {
      return read.GetString(prompt);
    }
  }
}