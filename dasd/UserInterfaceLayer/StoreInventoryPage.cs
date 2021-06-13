using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class StoreInventoryPage : Page
  {
    private string focusStore;
    public string FocusStore { get; set; }
    private int menuChoice;
    public int MenuChoice { get; set; }

    public StoreInventoryPage(string focusStore) : base()
    {
      this.FocusStore = focusStore;
      ManualInitializePageHeading($"{FocusStore} inventory", "Choose an item");
      List<string> StoreInventory = BL.DBInteract.GetStoreInventory(FocusStore);
      ManualInitializeOptionsList(StoreInventory);
    }

    public void ShowPage()
    {
      base.ShowPage();
      MenuChoice = UserInteract.GetInteger();
    }
  }
}
