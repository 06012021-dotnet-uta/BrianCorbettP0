using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class OrderHistoryPage : Page
  {
    /// <summary>
    /// Initializes the page heading and data that belongs on the page
    /// </summary>
    /// <param name="customerId">The ID of the customer to get order history of</param>
    /// <param name="storeId">The ID of the store that the order came from</param>
    public OrderHistoryPage(int customerId=-1, int storeId=-1) : base()
    {
      if (storeId == -1)
      {
        ManualInitializePageHeading("Your order history", "These are all of your orders\nPress enter when done viewing");
        ManualInitializeOptionsList(BL.DBInteract.GetCustomerOrderHistory(customerId), false);
      }
      else
      {
        string StoreLocation = BL.DBInteract.GetStoreLocationName(storeId);
        ManualInitializePageHeading($"Order history from {StoreLocation}", "Press enter when done viewing");
        ManualInitializeOptionsList(BL.DBInteract.GetStoreOrderHistory(storeId), false);
      }
    }

    /// <summary>
    /// Displays order history page data
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      UserInteract.GetString();
    }
  }
}
