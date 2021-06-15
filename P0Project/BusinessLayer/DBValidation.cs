using System.Linq;
using DB = P0DbContext;

namespace BusinessLayer
{
  public static class DBValidation
  {
    private static readonly DB.P0DbContext context = new();

    public static bool ValidateLogin(string userName, string passWord)
    {
      bool userMatch = context.Customers.Where(customer => (customer.Username == userName && customer.Pssword == passWord)).ToList().Any();
      return userMatch;
    }

    public static bool ValidateSignup(string userName)
    {
      bool userExists = context.Customers.Where(customer => customer.Username == userName).ToList().Any();
      return !userExists;
    }

    public static bool ValidateQuantity(int itemId, string focusStore, int desiredQuantity)
    {
      int ItemStock = DBInteract.GetItemStock(itemId, focusStore);
      return (desiredQuantity > 0 && desiredQuantity < ItemStock);
    }
  }
}