using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterfaceLayer
{
  public class PageNavigator
  {
    Dictionary<string, Page> pageDirectory = new Dictionary<string, Page>()
    {
      { "Landing", new LandingPage() },
      { "Login", new LoginPage() },
      { "Signup", new SignupPage() }//,
      //{ "Nav Options", new NavigationOptionsPage() },
      //{ "Order History", new OrderHistoryPage() },
      //{ "Choose Store", new ChooseStorePage() },
      //{ "Store Order History", new StoreOrderHistoryPage() },
      //{ "Store Inventory", new StoreInventoryPage() },
      //{ "Cart", new CartPage() },
      //{ "Checkout", new CheckoutPage() }
    };

    public bool StartPage(string page)
    {
      pageDirectory[page].ShowPage();
      return true;
    }
  }
}
