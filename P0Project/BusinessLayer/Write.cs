using System;

namespace BusinessLayer
{
  /// <summary>
  /// Defines methods to display messages to the customer
  /// </summary>
  public class Write : IWrite
  {
    /// <summary>
    /// Displays a message to the customer
    /// </summary>
    /// <param name="message">The message to display</param>
    public void PutLine(string message)
    {
      Console.WriteLine(message);
    }

    /// <summary>
    /// Capitalizes the first letter of a string
    /// </summary>
    /// <param name="strToCapitalize">The string to capitalize</param>
    /// <returns>The same string passed but with the first letter capitalized</returns>
    public string Capitalize(string strToCapitalize)
    {
      return char.ToUpper(strToCapitalize[0]) + strToCapitalize.Substring(1).ToLower();
    }
  }
}