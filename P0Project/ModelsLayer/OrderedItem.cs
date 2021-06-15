using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer
{
  public partial class OrderedItem
  {
    public int OrderId { get; set; }
    public int ItemId { get; set; }
    public int QuantityOrdered { get; set; }

    public virtual Item Item { get; set; }
    public virtual CustomerOrder Order { get; set; }
  }
}
