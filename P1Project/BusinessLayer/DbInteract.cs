using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using RepositoryLayer;

namespace BusinessLayer
{
  public class DbInteract : IDbInteract
  {
    private readonly P1Db _context;

    // register the context in Startup.ConfigureServices(); dependency injection (instantiated when this class is instantiated)
    public DbInteract(P1Db context)
    {
      this._context = context;
    }

    /// <summary>
    /// Saves a new customer in the Db. If unsuccessful, returns FALSE, else return TRUE
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    public async Task<bool> RegisterNewCustomer(CustomerModel customer)
    {
      var dbExistingCustomerResult = _context.Customers.Where(c => c.Username == customer.Username).ToList();
      if (dbExistingCustomerResult.Count != 0)
        return false;

      await _context.Customers.AddAsync(customer);

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException exc)
      {
        // instead of WriteLine use Logging for exception
        Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
        return false;
      }
      catch (DbUpdateException exc)
      {
        Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
        return false;
      }

      return true;
    }

    public bool VerifyCustomer(string username, string password)
    {
      var dbResult = _context.Customers.Where(customer => customer.Username == username && customer.Password == password).ToList();
      return (dbResult.Count == 1);
    }

    public int GetCustomerId(string username)
    {
      var dbResult = _context.Customers.Where(customer => customer.Username == username)
                                       .Select(customer => new { customer.CustomerId }).ToList();
      return dbResult[0].CustomerId;
    }

    public List<List<string>> GetCustomerSearchDetails(string userName="", string firstName="", string lastName="")
    {
      dynamic dbSearchResults;
      var CustomerTable = _context.Customers;
      if (userName != null && firstName != null && lastName != null)
      {
        dbSearchResults = CustomerTable.Where(customer => customer.Username == userName &&
                                                          customer.FirstName == firstName &&
                                                          customer.LastName == lastName).ToList();
      }
      else if (userName != null && firstName != null)
      {
        dbSearchResults = CustomerTable.Where(customer => customer.Username == userName &&
                                                          customer.FirstName == firstName).ToList();
      }
      else if (userName != null && lastName != null)
      {
        dbSearchResults = CustomerTable.Where(customer => customer.Username == userName &&
                                                          customer.LastName == lastName).ToList();
      }
      else if (firstName != null && lastName != null)
      {
        dbSearchResults = CustomerTable.Where(customer => customer.FirstName == firstName &&
                                                          customer.LastName == lastName).ToList();
      }
      else if (firstName != null)
      {
        dbSearchResults = CustomerTable.Where(customer => customer.FirstName == firstName).ToList();
      }
      else if (lastName != null)
      {
        dbSearchResults = CustomerTable.Where(customer => customer.LastName == lastName).ToList();
      }
      else if (userName != null)
      {
        dbSearchResults = CustomerTable.Where(customer => customer.Username == userName).ToList();
      }
      else
      {
        dbSearchResults = new List<string>();
      }

      List<List<string>> DisplayStrings = new();
      foreach (var res in dbSearchResults)
      {
        DisplayStrings.Add(new List<string>() {
            res.FirstName, res.LastName, res.Username, res.SignupDate.ToString()
          });
      }

      return DisplayStrings;
    }

    public CustomerModel GetCustomer(string userName, string passWord)
    {
      var dbResults = _context.Customers.Where(customer => customer.Username == userName && customer.Password == passWord).ToList();
      CustomerModel customer = new();
      foreach (var res in dbResults)
      {
        customer = new()
        {
          CustomerId = res.CustomerId,
          FirstName = res.FirstName,
          LastName = res.LastName,
          Username = res.Username,
          Password = res.Password,
          SignupDate = res.SignupDate
        };
      }
      return customer;
    }
  }
}
