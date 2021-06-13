using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer
{
    public partial class Item
    {
        public Item()
        {
            OrderedItems = new HashSet<OrderedItem>();
            StoredItems = new HashSet<StoredItem>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemDescription { get; set; }

        public virtual ICollection<OrderedItem> OrderedItems { get; set; }
        public virtual ICollection<StoredItem> StoredItems { get; set; }
    }
}
