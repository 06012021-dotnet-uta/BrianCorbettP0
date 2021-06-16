using System.Collections.Generic;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class ChooseStorePage : Page
  {
    private string storeChoice;
    /// <summary>
    /// Represents the store choice of the customer
    /// </summary>
    public string StoreChoice { get; set; }
    private readonly List<string> StoreLocations = BL.DBInteract.GetStoreLocations();

    /// <summary>
    /// Initializes the page heading and the data that belongs on the page
    /// </summary>
    public ChooseStorePage() : base()
    {
      ManualInitializePageHeading("Store locations", "Choose a store to order from");
      ManualInitializeOptionsList(StoreLocations);
    }

    /// <summary>
    /// Displays choose store page data and stores store choice from the customer
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      int MenuChoice = UserInteract.GetInteger();
      StoreChoice = StoreLocations[MenuChoice - 1];
    }
  }
}
