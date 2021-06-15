using System.Collections.Generic;

namespace UserInterfaceLayer
{
  public class StoreOptionsPage : Page
  {
    private int menuChoice;
    public int MenuChoice { get; }
    private string focusStore;
    public string FocusStore { get; }


    public StoreOptionsPage(string focusStore) : base()
    {
      this.focusStore = focusStore;
      ManualInitializePageHeading($"{focusStore} options", "Select an option");
      ManualInitializeOptionsList(new List<string>() { "Inventory", $"{focusStore} Order History" });
    }

    public void ShowPage()
    {
      base.ShowPage();
      menuChoice = UserInteract.GetInteger();
    }
  }
}
