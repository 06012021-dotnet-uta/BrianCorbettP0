using System.Collections.Generic;

namespace BusinessLayer
{
  /// <summary>
  /// Stores information about all the items the logged-in customer wishes to purchase
  /// </summary>
  public class CustomerCart
  {
    private List<List<int>> inCartItems;
    /// <summary>
    /// Stores information about the items in the logged-in customer's cart
    /// </summary>
    public List<List<int>> InCartItems { get; set; }
    private readonly int customerId;
    private decimal cartTotal = 0;
    /// <summary>
    /// Calculates the grand total of the logged-in customer's cart
    /// </summary>
    public decimal CartTotal { get; set; }

    /// <summary>
    /// Initializes InCartItems property and customerId field
    /// </summary>
    /// <param name="customerId">The ID of the logged-in customer</param>
    public CustomerCart(int customerId)
    {
      this.InCartItems = new List<List<int>>();
      this.customerId = customerId;
    }

    /// <summary>
    /// Adds items to the logged-in customer's cart
    /// </summary>
    /// <param name="itemId">ID of the item being added to the cart</param>
    /// <param name="storeId">ID of the store that the item is being oredered from</param>
    /// <param name="quantity">How many of the item is being added to the cart</param>
    public void AddToCart(int itemId, int storeId, int quantity)
    {
      List<int> details = new List<int>() { customerId, itemId, storeId, quantity };
      CartTotal += (DBInteract.GetItemPrice(itemId) * quantity);
      InCartItems.Add(details);
    }

    /// <summary>
    /// Removes all items from the Cart
    /// </summary>
    public void ClearAll()
    {
      InCartItems = new List<List<int>>();
    }

    /// <summary>
    /// Turns the items in the Cart into strings to display to the customer
    /// </summary>
    /// <returns>A list of string representations of the items in the Cart</returns>
    public List<string> DetailsToString()
    {
      List<string> cartStrings = new();
      foreach (var item in InCartItems)
      {
        int itemId = item[1];
        int purchQuantity = item[3];
        cartStrings.Add(DBInteract.GetItemCheckoutString(itemId, purchQuantity));
      }
      return cartStrings;
    }
  }
}
