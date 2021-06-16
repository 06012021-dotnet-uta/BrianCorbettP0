namespace BusinessLayer
{
  /// <summary>
  /// Defines methods to get information the customer and display messages to the customer
  /// </summary>
  public class UserInteract : IWrite, IRead
  {
    readonly Write write = new();
    readonly Read read = new();

    /// <summary>
    /// Displays text to the customer
    /// </summary>
    /// <param name="message">The text to display</param>
    public void PutLine(string message)
    {
      write.PutLine(message);
    }

    /// <summary>
    /// Gets an integer from the customer
    /// </summary>
    /// <param name="prompt">A prompt message to display before the input field</param>
    /// <returns>The integer inputted by the customer</returns>
    public int GetInteger(string prompt = "=> ")
    {
      return read.GetInteger(prompt);
    }
    /// <summary>
    /// Gets a string from the customer
    /// </summary>
    /// <param name="prompt">A prompt message to display before the input field</param>
    /// <returns>The string inputted by the customer</returns>
    public string GetString(string prompt="=> ")
    {
      return read.GetString(prompt);
    }
  }
}