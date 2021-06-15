using System.Collections.Generic;

namespace UserInterfaceLayer
{
  public class HomePage : Page
  {
    private int menuChoice;
    public int MenuChoice { get; }

    public HomePage() : base()
    {
      ManualInitializePageHeading("Home Page", "Select an option");
      List<string> optionsList = new() {
        "Choose Store",
        "Order History",
        "Customer Search",
        "Signout"
      };
      ManualInitializeOptionsList(optionsList);
    }

    public void ShowPage()
    {
      base.ShowPage();
      menuChoice = UserInteract.GetInteger();
    }
  }
}
