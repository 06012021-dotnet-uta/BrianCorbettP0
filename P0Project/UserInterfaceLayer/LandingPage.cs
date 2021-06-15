using System.Collections.Generic;

namespace UserInterfaceLayer
{
  public class LandingPage : Page
  {
    private int menuChoice;
    public int MenuChoice { get; }

    public LandingPage() : base()
    {
      ManualInitializePageHeading("Welcome to Golfs-a-lot!", "Login if you have account, signup if you don't.");
      ManualInitializeOptionsList(new List<string>() { "Login", "Signup", "Quit" });
    }

    public void ShowPage()
    {
      base.ShowPage();
      menuChoice = UserInteract.GetInteger();
    }
  }
}