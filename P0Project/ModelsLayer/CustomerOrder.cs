using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer
{
  public partial class CustomerOrder
  {
    public CustomerOrder()
    {
      OrderedItems = new HashSet<OrderedItem>();
    }

    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderCost { get; set; }
    public int CustomerId { get; set; }
    public int StoreId { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual ICollection<OrderedItem> OrderedItems { get; set; }
    public virtual Store Store { get; set; }
  }
}
