using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterfaceLayer
{
  public class StoreOptionsPage : Page
  {
    private int menuChoice;
    public int MenuChoice { get; set; }
    private string focusStore;
    public string FocusStore { get; set; }

    public StoreOptionsPage(string focusStore) : base()
    {
      ManualInitializePageHeading($"{focusStore} options", "Select an option");
      ManualInitializeOptionsList(new List<string>() { "Inventory", $"{focusStore} Order History" });
      this.FocusStore = focusStore;
    }

    public void ShowPage()
    {
      base.ShowPage();
      MenuChoice = UserInteract.GetInteger();
    }
  }
}
