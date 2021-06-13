using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = P0DbContext;

namespace BusinessLayer
{
  public static class DBInteract
  {
    static DB.P0DbContext context = new();

    public static List<string> GetStoreLocations()
    {
      var dbStoreLocations = context.Stores.Select(store => new { store.StoreLocation });
      List<string> StoreLocations = new();
      foreach (var location in dbStoreLocations.ToList())
      {
        StoreLocations.Add(location.StoreLocation);
      }
      return StoreLocations;
    }

    public static List<string> GetStoreInventory(string targetStore)
    {
      var StoresTable = context.Stores;
      var ItemsTable = context.Items;
      var InventoryTable = context.StoredItems;
      var dbStoreInventory = (from si in InventoryTable
                              join s in StoresTable on si.StoreId equals s.StoreId
                              join i in ItemsTable on si.ItemId equals i.ItemId
                              where s.StoreLocation == targetStore
                              select new
                              {
                                ItemName = i.ItemName,
                                ItemDesc = i.ItemDescription,
                                ItemPrice = Math.Round(i.ItemPrice, 4),
                                InStock = si.InStock
                              }).ToList();
      List<string> StoreInventory = new();
      foreach (var row in dbStoreInventory)
      {
        StoreInventory.Add($"{row.ItemName} ({row.InStock}) - ${row.ItemPrice}\n\t{row.ItemDesc}\n");
      }
      return StoreInventory;
    }
  }
}
