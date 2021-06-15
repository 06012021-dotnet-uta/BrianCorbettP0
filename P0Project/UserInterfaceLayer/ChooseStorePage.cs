using System.Collections.Generic;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class ChooseStorePage : Page
  {
    private string storeChoice;
    public string StoreChoice { get; }
    private readonly List<string> StoreLocations = BL.DBInteract.GetStoreLocations();

    public ChooseStorePage() : base()
    {
      ManualInitializePageHeading("Store locations", "Choose a store to order from");
      ManualInitializeOptionsList(StoreLocations);
    }

    public void ShowPage()
    {
      base.ShowPage();
      int MenuChoice = UserInteract.GetInteger();
      storeChoice = StoreLocations[MenuChoice - 1];
    }
  }
}
