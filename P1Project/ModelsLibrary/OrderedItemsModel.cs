using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
  public class OrderedItemsModel
  {
    public OrderedItemsModel() { }

    //[Key] [Column(Order=1)]
    //public int CustomerOrderId { get; set; }
    //[Key] [Column(Order=2)]
    //public int ItemId { get; set; }
    //[Required]
    //public int QuantityOrdered { get; set; }
    [Required] [Display(Name = "Order ID")]
    public int CustomerOrderId { get; set; }
    [Required] [Display(Name = "Item ID")]
    public int ItemId { get; set; }
    [Required] [Display(Name = "Quantity ordered")]
    public int QuantityOrdered { get; set; }
  }
}