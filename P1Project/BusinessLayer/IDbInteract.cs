using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public interface IDbInteract // this is created for testing the Db
  {
    Task<bool> RegisterNewCustomer(CustomerModel customer);
    bool VerifyCustomer(string username, string password);
    int GetCustomerId(string username);
    List<List<string>> GetCustomerSearchDetails(string userName = "", string firstName = "", string lastName = "");
    CustomerModel GetCustomer(string userName, string passWord);
  }
}
