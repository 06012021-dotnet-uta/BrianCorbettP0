using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer
{
  public partial class Customer
  {
    public Customer()
    {
      CustomerOrders = new HashSet<CustomerOrder>();
    }

    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Pssword { get; set; }
    public DateTime SignupDate { get; set; }

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
  }
}
