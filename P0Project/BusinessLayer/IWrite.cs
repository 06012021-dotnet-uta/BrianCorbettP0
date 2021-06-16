namespace BusinessLayer
{
  /// <summary>
  /// Declares methods to write messages to the customer
  /// </summary>
  public interface IWrite
  {
    void PutLine(string message);
  }
}