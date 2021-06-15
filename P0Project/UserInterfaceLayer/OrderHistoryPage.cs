using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class OrderHistoryPage : Page
  {
    public OrderHistoryPage(int customerId, int storeId=-1) : base()
    {
      if (storeId == -1)
      {
        ManualInitializePageHeading("Your order history", "These are all of your orders\nPress enter when done viewing");
        ManualInitializeOptionsList(BL.DBInteract.GetCustomerOrderHistory(customerId), false);
      }
      else
      {
        string StoreLocation = BL.DBInteract.GetStoreLocationName(storeId);
        ManualInitializePageHeading($"Your order history from {StoreLocation}", "These are all of your orders\nPress enter when done viewing");
        ManualInitializeOptionsList(BL.DBInteract.GetStoreCustomerOrderHistory(customerId, storeId), false);
      }
    }

    public void ShowPage()
    {
      base.ShowPage();
      UserInteract.GetString();
    }
  }
}
