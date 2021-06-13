using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer
{
    public partial class StoredItem
    {
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public int InStock { get; set; }

        public virtual Item Item { get; set; }
        public virtual Store Store { get; set; }
    }
}
