using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer
{
    public partial class Store
    {
        public Store()
        {
            StoredItems = new HashSet<StoredItem>();
        }

        public int StoreId { get; set; }
        public string StoreLocation { get; set; }

        public virtual ICollection<StoredItem> StoredItems { get; set; }
    }
}
