using System.Linq;
using DB = P0DbContext;

namespace BusinessLayer
{
  public static class DBValidation
  {
    static DB.P0DbContext context = new();

    public static bool ValidateLogin(string userName, string passWord)
    {
      bool userMatch = context.Customers.Where(x => (x.Username == userName && x.Pssword == passWord)).ToList().Any();
      return userMatch;
    }

    public static bool ValidateSignup(string userName)
    {
      bool userExists = context.Customers.Where(x => x.Username == userName).ToList().Any();
      return !userExists;
    }
  }
}