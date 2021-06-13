using System.Collections.Generic;
using System;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public abstract class Page
  {
    private PageHeading pageHeading;
    private Menu menu;
    public BL.UserInteract UserInteract = new BL.UserInteract();

    protected void ManualInitializePageHeading(string title, string prompt)
    {
      pageHeading = new PageHeading(title, prompt);
    }
    protected void ManualInitializeOptionsList(List<string> options)
    {
      menu = new Menu(options);
    }

    public void LoadPage()
    {
      Console.Clear();
    }
    public void ShowPage()
    {
      LoadPage();
      pageHeading.Display();
      if (menu != null)
      {
        menu.PlaceMenu();
      }
    }
  }
}