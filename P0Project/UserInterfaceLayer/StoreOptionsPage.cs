using System.Collections.Generic;

namespace UserInterfaceLayer
{
  public class StoreOptionsPage : Page
  {
    private int menuChoice;
    /// <summary>
    /// Represents the menu options chosen by the customer
    /// </summary>
    public int MenuChoice { get; set; }
    private string focusStore;
    /// <summary>
    /// Represents the name of the store location in focus
    /// </summary>
    public string FocusStore { get; set; }

    /// <summary>
    /// Initializes the page heading, data, and the focus store of page
    /// </summary>
    /// <param name="focusStore">The name of the store location in focus</param>
    public StoreOptionsPage(string focusStore) : base()
    {
      this.FocusStore = focusStore;
      ManualInitializePageHeading($"{FocusStore} options", "Select an option");
      ManualInitializeOptionsList(new List<string>() { "Inventory", $"{FocusStore} Order History", "Back" });
    }

    /// <summary>
    /// Displays store options page and stores menu choice of the customer
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      MenuChoice = UserInteract.GetInteger();
    }
  }
}
