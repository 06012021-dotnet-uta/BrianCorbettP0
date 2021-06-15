using System.Collections.Generic;

namespace BusinessLayer
{
  public class CustomerCart
  {
    private List<List<int>> inCartItems;
    public List<List<int>> InCartItems { get; }
    private readonly int customerId;
    private decimal cartTotal = 0;
    public decimal CartTotal { get; }

    public CustomerCart(int customerId)
    {
      this.inCartItems = new List<List<int>>();
      this.customerId = customerId;
    }

    public void AddToCart(int itemId, int storeId, int quantity)
    {
      List<int> details = new List<int>() { customerId, itemId, storeId, quantity };
      cartTotal += (DBInteract.GetItemPrice(itemId) * quantity);
      inCartItems.Add(details);
    }

    public void ClearAll()
    {
      inCartItems = new List<List<int>>();
      cartTotal = 0;
    }

    public List<string> DetailsToString()
    {
      List<string> cartStrings = new();
      foreach (var item in inCartItems)
      {
        int itemId = item[1];
        int purchQuantity = item[3];
        cartStrings.Add(DBInteract.GetItemCheckoutString(itemId, purchQuantity));
      }
      return cartStrings;
    }
  }
}
