using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
  public class StoredItemsModel
  {
    public StoredItemsModel() { }

    //[Key] [Column(Order=1)] [Display(Name = "Item ID")]
    //public int ItemId { get; set; }
    //[Key] [Column(Order=2)] [Display(Name = "Store ID")]
    //public int StoreId { get; set; }
    //[Required] [Display(Name = "In Stock")]
    //public int InStock { get; set; } = 0;
    [Required] [Display(Name = "Item ID")]
    public int ItemId { get; set; }
    [Required] [Display(Name = "Store ID")]
    public int StoreId { get; set; }
    [Required]
    [Display(Name = "In Stock")]
    public int InStock { get; set; } = 0;
  }
}
