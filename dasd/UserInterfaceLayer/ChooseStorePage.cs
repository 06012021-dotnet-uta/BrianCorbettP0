using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class ChooseStorePage : Page
  {
    private string storeChoice;
    public string StoreChoice { get; set; }
    private List<string> StoreLocations = BL.DBInteract.GetStoreLocations();

    public ChooseStorePage() : base()
    {
      ManualInitializePageHeading("Store locations", "Choose a store to order from");
      ManualInitializeOptionsList(StoreLocations);
    }

    public void ShowPage()
    {
      base.ShowPage();
      int MenuChoice = UserInteract.GetInteger();
      StoreChoice = StoreLocations[MenuChoice - 1];
    }
  }
}
