using System.Collections.Generic;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class Menu : BL.Write
  {
    private readonly List<string> OptionsList;
    private readonly bool ShowNumbers;

    /// <summary>
    /// Defines the options of the menu
    /// </summary>
    /// <param name="optionsList">The string list of the options of the menu</param>
    /// <param name="showNumbers">Whether or not to make the menu numbered</param>
    public Menu(List<string> optionsList, bool showNumbers=true)
    {
      this.ShowNumbers = showNumbers;
      this.OptionsList = optionsList;
    }

    /// <summary>
    /// Displays the menu to the customer
    /// </summary>
    public void PlaceMenu()
    {
      for (int indx = 1; indx < (OptionsList.Count + 1); indx++)
      {
        if (ShowNumbers) PutLine($"{indx}. {OptionsList[indx - 1]}");
        else PutLine($"{OptionsList[indx - 1]}");
      }
    }
  }
}