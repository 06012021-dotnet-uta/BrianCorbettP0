using System.Collections.Generic;
using System;
namespace UserInterfaceLayer
{
  public class LandingPage : Page
  {
    private int menuChoice;
    public int MenuChoice { get; set; }

    public LandingPage() : base()
    {
      ManualInitializePageHeading("Welcome to Golfs-a-lot!", "Login if you have account, signup if you don't.");
      ManualInitializeOptionsList(
        new List<string>() { "Login", "Signup", "Quit" });
    }

    public void ShowPage()
    {
      base.ShowPage();
      MenuChoice = UserInteract.GetInteger();
    }
  }
}