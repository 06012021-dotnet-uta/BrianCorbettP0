using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterfaceLayer
{
  public class HomePage : Page
  {
    private int menuChoice;
    public int MenuChoice { get; set; }

    public HomePage() : base()
    {
      ManualInitializePageHeading("Home Page", "Select an option");
      List<string> optionsList = new List<string>() {
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
      MenuChoice = UserInteract.GetInteger();
    }
  }
}
