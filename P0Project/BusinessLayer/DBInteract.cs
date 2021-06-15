using System;
using System.Collections.Generic;
using System.Linq;
using DB = P0DbContext;

namespace BusinessLayer
{
  public static class DBInteract
  {
    static DB.P0DbContext context = new();

    public static List<string> GetStoreLocations()
    {
      var dbStoreLocations = context.Stores.Select(store => new { store.StoreLocation }).ToList();
      List<string> StoreLocations = new();
      foreach (var location in dbStoreLocations)
        StoreLocations.Add(location.StoreLocation);
      return StoreLocations;
    }

    public static List<string> GetStoreInventory(string focusStore)
    {
      var StoresTable = context.Stores;
      var ItemsTable = context.Items;
      var InventoryTable = context.StoredItems;
      var dbStoreInventory = (from si in InventoryTable
                              join s in StoresTable on si.StoreId equals s.StoreId
                              join i in ItemsTable on si.ItemId equals i.ItemId
                              where s.StoreLocation == focusStore
                              select new
                              {
                                i.ItemName,
                                ItemDesc = i.ItemDescription,
                                ItemPrice = Math.Round(i.ItemPrice, 4),
                                si.InStock
                              }).ToList();
      List<string> StoreInventory = new();
      foreach (var row in dbStoreInventory)
        StoreInventory.Add($"{row.ItemName} ({row.InStock}) - ${row.ItemPrice}\n\t{row.ItemDesc}\n");
      return StoreInventory;
    }

    public static int GetItemStock(int itemId, string focusStore)
    {
      var StoresTable = context.Stores;
      var ItemsTable = context.Items;
      var InventoryTable = context.StoredItems;
      var dbItemStock = (from si in InventoryTable
                         join s in StoresTable on si.StoreId equals s.StoreId
                         join i in ItemsTable on si.ItemId equals i.ItemId
                         where s.StoreLocation == focusStore && i.ItemId == itemId
                         select new
                         {
                           si.InStock
                         }).ToList();
      return dbItemStock[0].InStock;
    }

    public static string GetItemCheckoutString(int itemId, int quantity)
    {
      var ItemsTable = context.Items;
      var dbItem = ItemsTable.Where(item => item.ItemId == itemId).Select(item => new { item.ItemName, item.ItemPrice }).ToList();
      string ItemName = "";
      decimal ItemPrice = 0;
      foreach (var detail in dbItem)
      {
        ItemName = detail.ItemName;
        ItemPrice = detail.ItemPrice;
      }
      return $"{ItemName} -- quantity {quantity} -> ${ItemPrice * quantity}";
    }

    public static decimal GetItemPrice(int itemId)
    {
      var ItemsTable = context.Items;
      var dbItem = ItemsTable.Where(item => item.ItemId == itemId).Select(item => new { item.ItemPrice }).ToList();
      decimal ItemPrice = 0;
      foreach (var item in dbItem)
        ItemPrice = item.ItemPrice;
      return ItemPrice;
    }

    public static void DecreaseInStock(int itemId, int storeId, int quantity)
    {
      var InventoryTable = context.StoredItems;
      var dbInventoryItem = InventoryTable.Where(storedItem => storedItem.ItemId == itemId && storedItem.StoreId == storeId);
      foreach (var item in dbInventoryItem)
        item.InStock -= quantity;
      context.SaveChanges();
    }

    public static int GetCustomerId(string userName, string passWord)
    {
      var dbCustomerId = context.Customers.Where(customer => customer.Username == userName && customer.Pssword == passWord)
                                          .Select(customer => new { customer.CustomerId }).ToList();
      return dbCustomerId[0].CustomerId;
    }

    public static int GetStoreId(string focusStore)
    {
      var dbStoreId = context.Stores.Where(store => store.StoreLocation == focusStore)
                                    .Select(store => new { store.StoreId }).ToList();
      return dbStoreId[0].StoreId;
    }

    public static string GetStoreLocationName(int storeId)
    {
      var dbStoreLoc = context.Stores.Where(store => store.StoreId == storeId)
                                     .Select(store => new { store.StoreLocation }).ToList();
      return dbStoreLoc[0].StoreLocation;
    }

    public static List<string> GetStoreCustomerOrderHistory(int customerId, int storeId)
    {
      List<string> OrderHistory = new();
      var OrdersTable = context.CustomerOrders;
      var CustomersTable = context.Customers;
      var StoresTable = context.Stores;
      var dbCustomerOrders = (from o in OrdersTable
                              join s in StoresTable on o.StoreId equals s.StoreId
                              join c in CustomersTable on o.CustomerId equals c.CustomerId
                              where o.CustomerId == customerId && o.StoreId == storeId
                              select new
                              {
                                o.OrderId,
                                o.OrderDate,
                                o.OrderCost
                              }).ToList();

      var ItemsTable = context.Items;
      var OrderedItemsTable = context.OrderedItems;
      var dbItemsOrdered = (from oi in OrderedItemsTable
                            join o in OrdersTable on oi.OrderId equals o.OrderId
                            join i in ItemsTable on oi.ItemId equals i.ItemId
                            where o.CustomerId == customerId
                            select new
                            {
                              o.OrderId,
                              i.ItemName,
                              Quantity = oi.QuantityOrdered
                            }).ToList();

      foreach (var order in dbCustomerOrders)
      {
        OrderHistory.Add($"Order Id {order.OrderId} on {order.OrderDate:yyyy-MM-dd}, Total cost: ${order.OrderCost}");
        foreach (var orderedItem in dbItemsOrdered)
        {
          if (orderedItem.OrderId == order.OrderId)
            OrderHistory.Add($"\t{orderedItem.ItemName} (quantity: {orderedItem.Quantity})");
        }
      }
      return OrderHistory;
    }

    public static List<string> GetCustomerOrderHistory(int customerId)
    {
      List<string> OrderHistory = new();
      var StoresTable = context.Stores;
      var OrdersTable = context.CustomerOrders;
      var CustomersTable = context.Customers;
      var dbCustomerOrders = (from o in OrdersTable
                              join c in CustomersTable on o.CustomerId equals c.CustomerId
                              join s in StoresTable on o.StoreId equals s.StoreId
                              where o.CustomerId == customerId
                              select new
                              {
                                o.OrderId,
                                o.OrderDate,
                                o.OrderCost,
                                s.StoreLocation
                              }).ToList();

      var ItemsTable = context.Items;
      var OrderedItemsTable = context.OrderedItems;
      var dbItemsOrdered = (from oi in OrderedItemsTable
                            join o in OrdersTable on oi.OrderId equals o.OrderId
                            join i in ItemsTable on oi.ItemId equals i.ItemId
                            where o.CustomerId == customerId
                            select new
                            {
                              o.OrderId,
                              i.ItemName,
                              Quantity = oi.QuantityOrdered
                            }).ToList();

      foreach (var order in dbCustomerOrders)
      {
        OrderHistory.Add($"Order Id {order.OrderId} on {order.OrderDate:yyyy-MM-dd} from {order.StoreLocation}, Total cost: ${order.OrderCost}");
        foreach (var orderedItem in dbItemsOrdered)
        {
          if (orderedItem.OrderId == order.OrderId)
            OrderHistory.Add($"\t{orderedItem.ItemName} (quantity: {orderedItem.Quantity})");
        }
      }
      return OrderHistory;
    }
  }
}
