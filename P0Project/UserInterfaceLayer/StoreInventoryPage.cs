using System.Collections.Generic;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class StoreInventoryPage : Page
  {
    private readonly int storeId;
    public int StoreId { get; }
    private int menuChoice;
    public int MenuChoice { get; }
    private int desiredQuantity;
    public int DesiredQuantity { get; }

    public StoreInventoryPage(string focusStore) : base()
    {
      this.storeId = BL.DBInteract.GetStoreId(focusStore);
      ManualInitializePageHeading($"{focusStore} inventory", "Choose a number corresponding to the item you want to purchase\n" +
        "Type a negative number to place the order");
      List<string> StoreInventory = BL.DBInteract.GetStoreInventory(focusStore);
      ManualInitializeOptionsList(StoreInventory);
    }

    public void ShowPage()
    {
      base.ShowPage();
      menuChoice = UserInteract.GetInteger();
      if (menuChoice < 0) { return; }
      desiredQuantity = UserInteract.GetInteger("Quantity => ");
    }
  }
}
