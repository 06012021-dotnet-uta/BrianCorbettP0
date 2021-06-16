using System;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
  /// <summary>
  /// Defines methods to get input from the customer
  /// </summary>
  public class Read : IRead
  {
    /// <summary>
    /// Gets an integer from the customer
    /// </summary>
    /// <param name="prompt">A prompt message to display before the input field</param>
    /// <returns>The integer inputted by the customer</returns>
    public int GetInteger(string prompt = "=> ")
    {
      Console.Write(prompt);
      string UserInput = Console.ReadLine();
      bool successfulConversion = Int32.TryParse(UserInput, out int UserInputInt);
      if (successfulConversion && UserInputInt >= 1) return UserInputInt;
      else return -1;
    }

    /// <summary>
    /// Gets a string from the integer
    /// </summary>
    /// <param name="prompt">A prompt message to display before the input field</param>
    /// <returns>The string inputted by the customer</returns>
    public string GetString(string prompt = "=> ")
    {
      Console.Write(prompt);
      return Console.ReadLine();
    }

    /// <summary>
    /// Removes specified unwanted characters from a string
    /// </summary>
    /// <param name="strIn">The string to clean</param>
    /// <param name="removeChars">A regex string specifying which characters to remove</param>
    /// <returns>A string with the specified characters removed</returns>
    public string CleanInput(string strIn, string removeChars)
    {
      // Replace invalid characters with empty strings.
      try
      {
        return Regex.Replace(strIn, removeChars, "",
                             RegexOptions.None, TimeSpan.FromSeconds(1.5));
      }
      // If we timeout when replacing invalid characters,
      // we should return Empty.
      catch (RegexMatchTimeoutException)
      {
        return String.Empty;
      }
    }
  }
}