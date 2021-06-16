using System.Collections.Generic;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class StoreInventoryPage : Page
  {
    private readonly int storeId;
    /// <summary>
    /// Represents the ID of the store to get inventory of
    /// </summary>
    public int StoreId { get; set; }
    private int menuChoice;
    /// <summary>
    /// Represents the menu options chosen by the customer
    /// </summary>
    public int MenuChoice { get; set; }
    private int desiredQuantity;
    /// <summary>
    /// Represents the quantity of the item the customer wants to buy
    /// </summary>
    public int DesiredQuantity { get; set; }

    /// <summary>
    /// Initializes the page heading and the data that belongs on the page
    /// </summary>
    public StoreInventoryPage(string focusStore) : base()
    {
      this.StoreId = BL.DBInteract.GetStoreId(focusStore);
      ManualInitializePageHeading($"{focusStore} inventory", "Choose a number corresponding to the item you want to purchase\n" +
        "Type a negative number to place the order");
      List<string> StoreInventory = BL.DBInteract.GetStoreInventory(focusStore);
      ManualInitializeOptionsList(StoreInventory);
    }

    /// <summary>
    /// Displays store inventory page and stores the desired quantity of the customer
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      MenuChoice = UserInteract.GetInteger();
      if (MenuChoice < 0) { return; }
      DesiredQuantity = UserInteract.GetInteger("Quantity => ");
    }
  }
}
