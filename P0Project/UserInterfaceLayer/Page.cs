using System.Collections.Generic;
using System;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public abstract class Page
  {
    private PageHeading pageHeading;
    private Menu menu;
    protected BL.UserInteract UserInteract = new();

    protected void ManualInitializePageHeading(string title, string prompt)
    {
      pageHeading = new PageHeading(title, prompt);
    }
    protected void ManualInitializeOptionsList(List<string> options, bool showNumbers=true)
    {
      menu = new Menu(options, showNumbers);
    }

    /// <summary>
    /// Displays the page
    /// </summary>
    public void ShowPage()
    {
      Console.Clear();
      pageHeading.Display();
      if (menu != null) menu.PlaceMenu();
    }
  }
}