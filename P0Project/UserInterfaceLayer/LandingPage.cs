using System.Collections.Generic;

namespace UserInterfaceLayer
{
  public class LandingPage : Page
  {
    private int menuChoice;
    /// <summary>
    /// Represents the menu option chosen by the customer
    /// </summary>
    public int MenuChoice { get; set; }

    /// <summary>
    /// Initializes the page heading and the data that belongs on the page
    /// </summary>
    public LandingPage() : base()
    {
      ManualInitializePageHeading("Welcome to Golfs-a-lot!", "Login if you have account, signup if you don't.");
      ManualInitializeOptionsList(new List<string>() { "Login", "Signup", "Quit" });
    }

    /// <summary>
    /// Displays landing page data and stores menu choice of the customer
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      MenuChoice = UserInteract.GetInteger();
    }
  }
}