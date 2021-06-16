namespace BusinessLayer
{
  /// <summary>
  /// Declares methods to get strings or integers from the customer
  /// </summary>
  public interface IRead
  {
    int GetInteger(string prompt = "=> ");
    string GetString(string prompt = "=> ");
  }
}