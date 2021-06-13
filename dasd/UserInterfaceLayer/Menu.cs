using System.Collections.Generic;
using System;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class Menu
  {
    BL.UserInteract userInteract = new BL.UserInteract();
    List<string> OptionsList;

    public Menu(List<string> optionsList)
    {
      this.OptionsList = optionsList;
    }

    public void PlaceMenu()
    {
      for (int i = 1; i < (OptionsList.Count + 1); i++)
      {
        userInteract.PutLine($"{i}. {OptionsList[i - 1]}");
      }
    }
  }
}