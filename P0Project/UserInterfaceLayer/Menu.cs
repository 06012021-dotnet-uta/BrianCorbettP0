using System.Collections.Generic;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class Menu : BL.Write
  {
    private readonly List<string> OptionsList;
    private readonly bool ShowNumbers;

    public Menu(List<string> optionsList, bool showNumbers=true)
    {
      this.ShowNumbers = showNumbers;
      this.OptionsList = optionsList;
    }

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