using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class CustomerSearchPage : Page
  {
    /// <summary>
    /// Initializes the page heading that belongs on the page
    /// </summary>
    public CustomerSearchPage() : base()
    {
      ManualInitializePageHeading("Customer search", "Search by username, first name, last name, or first and last name");
    }

    /// <summary>
    /// Displays customer search page data
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      string CustomerSearch = UserInteract.GetString().Trim();
      ManualInitializeOptionsList(BL.DBInteract.GetCustomerDetails(CustomerSearch));
      base.ShowPage();
      UserInteract.GetString();
    }
  }
}
