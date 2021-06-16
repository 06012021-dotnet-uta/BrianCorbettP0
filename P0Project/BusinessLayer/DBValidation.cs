using System.Linq;
using DB = P0DbContext;

namespace BusinessLayer
{
  /// <summary>
  /// A class to handle validation against the database
  /// </summary>
  public static class DBValidation
  {
    private static readonly DB.P0DbContext context = new();

    /// <summary>
    /// Makes sure there's a record in the database with the username and password
    /// </summary>
    /// <param name="userName">The username of the customer</param>
    /// <param name="passWord">The password of the customer</param>
    /// <returns>A bool representing if there was a match in the database</returns>
    public static bool ValidateLogin(string userName, string passWord)
    {
      bool userMatch = context.Customers.Where(customer => (customer.Username == userName && customer.Pssword == passWord)).ToList().Any();
      return userMatch;
    }

    /// <summary>
    /// Makes sure the username isn't taken
    /// </summary>
    /// <param name="userName">The username of the new customer</param>
    /// <returns>A bool representing if there exists the same username in the database</returns>
    public static bool ValidateSignup(string userName)
    {
      bool userExists = context.Customers.Where(customer => customer.Username == userName).ToList().Any();
      return !userExists;
    }

    /// <summary>
    /// Makes sure the quantity of an item a customer wants to buy is greater than 0 but less than
    /// the amount in stock the store has
    /// </summary>
    /// <param name="itemId">The ID of the item the customer wants to buy</param>
    /// <param name="focusStore">The store location the customer is ordering from</param>
    /// <param name="desiredQuantity">The quantity of the item the customer wants to buy</param>
    /// <returns></returns>
    public static bool ValidateQuantity(int itemId, string focusStore, int desiredQuantity)
    {
      int ItemStock = DBInteract.GetItemStock(itemId, focusStore);
      return (desiredQuantity > 0 && desiredQuantity < ItemStock);
    }
  }
}