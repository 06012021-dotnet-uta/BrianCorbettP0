using System.Collections.Generic;

namespace UserInterfaceLayer
{
  public class HomePage : Page
  {
    private int menuChoice;
    /// <summary>
    /// Represents which menu option the customer chose
    /// </summary>
    public int MenuChoice { get; set; }
    /// <summary>
    /// Initializes the page heading and the data that belongs on the page
    /// </summary>
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

    /// <summary>
    /// Displays home page data and stores menu choice of the customer
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      MenuChoice = UserInteract.GetInteger();
    }
  }
}
