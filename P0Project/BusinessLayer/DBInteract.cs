using System;
using System.Collections.Generic;
using System.Linq;
using DB = P0DbContext;

namespace BusinessLayer
{
  /// <summary>
  /// Methods to retrieve information from the database
  /// </summary>
  public static class DBInteract
  {
    readonly static DB.P0DbContext context = new();

    /// <summary>
    /// Get all the store locations that exists in the database
    /// </summary>
    /// <returns>A string list of the store locations</returns>
    public static List<string> GetStoreLocations()
    {
      var dbStoreLocations = context.Stores.Select(store => new { store.StoreLocation }).ToList();
      List<string> StoreLocations = new();
      foreach (var location in dbStoreLocations)
        StoreLocations.Add(location.StoreLocation);
      return StoreLocations;
    }

    /// <summary>
    /// Gets the inventory for a store
    /// </summary>
    /// <param name="focusStore">The name of the store location in focus</param>
    /// <returns>A list of string representations of the inventory at the store location</returns>
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

    /// <summary>
    /// Gets the quantity in stock of an item at the store
    /// </summary>
    /// <param name="itemId">The ID of the item to get the stock of</param>
    /// <param name="focusStore">The name of the store location to check the inventory of</param>
    /// <returns>An integer representing the amount in stock of the item at the store</returns>
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

    /// <summary>
    /// Gets information to display to customer about a checkout item
    /// </summary>
    /// <param name="itemId">The ID of the item to get the information for</param>
    /// <param name="quantity">The number of that item that was bought</param>
    /// <returns>A string representation of the checkout item's information</returns>
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
      return $"{ItemName} -- quantity {quantity} -> ${ItemPrice * quantity}\n";
    }

    /// <summary>
    /// Gets the price of an item
    /// </summary>
    /// <param name="itemId">The ID of the item to get the price of</param>
    /// <returns>A decimal representing the price of the item</returns>
    public static decimal GetItemPrice(int itemId)
    {
      var ItemsTable = context.Items;
      var dbItem = ItemsTable.Where(item => item.ItemId == itemId).Select(item => new { item.ItemPrice }).ToList();
      decimal ItemPrice = 0;
      foreach (var item in dbItem)
        ItemPrice = item.ItemPrice;
      return ItemPrice;
    }

    /// <summary>
    /// Decreases the amount in stock at a store location based on the amount bought by customer
    /// </summary>
    /// <param name="itemId">The ID of the item whose amount in stock to modify</param>
    /// <param name="storeId">The ID of the store whose inventory to modify</param>
    /// <param name="quantity">The amount by which to decrease the amount in stock</param>
    public static void DecreaseInStock(int itemId, int storeId, int quantity)
    {
      var InventoryTable = context.StoredItems;
      var dbInventoryItem = InventoryTable.Where(storedItem => storedItem.ItemId == itemId && storedItem.StoreId == storeId);
      foreach (var item in dbInventoryItem)
        item.InStock -= quantity;
      context.SaveChanges();
    }

    /// <summary>
    /// Gets the ID of a user based on a username
    /// </summary>
    /// <param name="userName">The username of the customer to get the ID of</param>
    /// <param name="passWord">The password of the customer to get the ID of</param>
    /// <returns>An integer representing the ID of the customer</returns>
    public static int GetCustomerId(string userName, string passWord)
    {
      var dbCustomerId = context.Customers.Where(customer => customer.Username == userName && customer.Pssword == passWord)
                                          .Select(customer => new { customer.CustomerId }).ToList();
      if (dbCustomerId.Any())
        return dbCustomerId[0].CustomerId;
      return -1;
    }

    /// <summary>
    /// Gets information of a customer
    /// </summary>
    /// <param name="searchQuery">Either a first name, last name, both, or username of a customer</param>
    /// <returns>A string list containing string representations of customers that match the searchQuery</returns>
    public static List<string> GetCustomerDetails(string searchQuery)
    {
      Write write = new();
      dynamic dbCustomerSearchResults;
      if (searchQuery.Split(' ').Length > 1)
      {
        string FirstName = write.Capitalize(searchQuery.Split(' ')[0]);
        string LastName = write.Capitalize(searchQuery.Split(' ')[1]);
        dbCustomerSearchResults = context.Customers.Where(customer => (customer.FirstName == FirstName &&
                                                                     customer.LastName == LastName)).ToList();
      }
      else
      {
        dbCustomerSearchResults = context.Customers.Where(customer => ((customer.Username == searchQuery) ||
                                                                     (customer.FirstName == write.Capitalize(searchQuery)) ||
                                                                     (customer.LastName == write.Capitalize(searchQuery))))
                                                   .Select(customer => new
                                                   {
                                                     customer.FirstName,
                                                     customer.LastName,
                                                     customer.Username,
                                                     customer.SignupDate
                                                   }).ToList();
      }

      List<string> CustomerSearchResults = new();
      foreach (var detail in dbCustomerSearchResults)
      {
        CustomerSearchResults.Add($"{detail.FirstName} {detail.LastName} ({detail.Username}) signed up on {detail.SignupDate:yyyy-MM-dd}\n");
      }
      return CustomerSearchResults;
    }

    /// <summary>
    /// Gets the ID of a store based on the store lcoation
    /// </summary>
    /// <param name="focusStore">The store location of a store to get the ID</param>
    /// <returns>An integer representing the ID of the store location</returns>
    public static int GetStoreId(string focusStore)
    {
      var dbStoreId = context.Stores.Where(store => store.StoreLocation == focusStore)
                                    .Select(store => new { store.StoreId }).ToList();
      return dbStoreId[0].StoreId;
    }

    /// <summary>
    /// Gets the name of a store location
    /// </summary>
    /// <param name="storeId">The ID of a store get the location</param>
    /// <returns>A string representation of the store location name</returns>
    public static string GetStoreLocationName(int storeId)
    {
      var dbStoreLoc = context.Stores.Where(store => store.StoreId == storeId)
                                     .Select(store => new { store.StoreLocation }).ToList();
      return dbStoreLoc[0].StoreLocation;
    }

    /// <summary>
    /// Gets the order history of certain store location
    /// </summary>
    /// <param name="storeId">The ID of a store to get the order history of</param>
    /// <returns>A list of string representations of the store's order history</returns>
    public static List<string> GetStoreOrderHistory(int storeId)
    {
      List<string> OrderHistory = new();
      var OrdersTable = context.CustomerOrders;
      var CustomersTable = context.Customers;
      var StoresTable = context.Stores;
      var dbCustomerOrders = (from o in OrdersTable
                              join s in StoresTable on o.StoreId equals s.StoreId
                              join c in CustomersTable on o.CustomerId equals c.CustomerId
                              where o.StoreId == storeId
                              select new
                              {
                                o.OrderId,
                                o.OrderDate,
                                o.OrderCost,
                                c.Username
                              }).ToList();

      var ItemsTable = context.Items;
      var OrderedItemsTable = context.OrderedItems;
      var dbItemsOrdered = (from oi in OrderedItemsTable
                            join o in OrdersTable on oi.OrderId equals o.OrderId
                            join i in ItemsTable on oi.ItemId equals i.ItemId
                            where o.StoreId == storeId
                            select new
                            {
                              o.OrderId,
                              i.ItemName,
                              Quantity = oi.QuantityOrdered
                            }).ToList();

      foreach (var order in dbCustomerOrders)
      {
        OrderHistory.Add($"Order Id {order.OrderId} by {order.Username} on {order.OrderDate:yyyy-MM-dd}, Total cost: ${order.OrderCost}");
        foreach (var orderedItem in dbItemsOrdered)
        {
          if (orderedItem.OrderId == order.OrderId)
            OrderHistory.Add($"\t{orderedItem.ItemName} (quantity: {orderedItem.Quantity})");
        }
        OrderHistory.Add("\n");

      }
      return OrderHistory;
    }

    /// <summary>
    /// Gets the order history of a customer
    /// </summary>
    /// <param name="customerId">The ID of a customer to get order history of</param>
    /// <returns>A list of string representations of the orders and their details</returns>
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
        OrderHistory.Add("\n");
      }
      return OrderHistory;
    }
  }
}
