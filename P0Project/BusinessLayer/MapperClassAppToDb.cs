using System;
using System.Globalization;
using ML = ModelsLayer;

namespace BusinessLayer
{
  /// <summary>
  /// Defines methods to map application information to entities in the database
  /// </summary>
  public static class MapperClassAppToDb
  {
    /// <summary>
    /// Maps customer information to a Customer entity in the database
    /// </summary>
    /// <param name="firstName">The first name of the customer</param>
    /// <param name="lastName">The last name of the customer</param>
    /// <param name="userName">The username of the customer</param>
    /// <param name="passWord">The password of the customer</param>
    /// <returns>A database-compatible Customer entity</returns>
    public static ML.Customer AppCustomerToDbCustomer(
      string firstName, string lastName, string userName, string passWord)
    {
      ML.Customer newCustomer = new()
      {
        FirstName = firstName,
        LastName = lastName,
        Username = userName,
        Pssword = passWord,
        SignupDate = DateTime.Now
      };
      return newCustomer;
    }

    /// <summary>
    /// Maps item information to an Item entity in the database
    /// </summary>
    /// <param name="itemName">The name of the item</param>
    /// <param name="itemPrice">The price of the item</param>
    /// <param name="itemDescription">A description of an item</param>
    /// <returns>A database-compatible Item entity</returns>
    public static ML.Item AppItemToDbItem(
      string itemName, decimal itemPrice, string itemDescription)
    {
      ML.Item newItem = new()
      {
        ItemName = itemName,
        ItemPrice = itemPrice,
        ItemDescription = itemDescription
      };
      return newItem;
    }

    /// <summary>
    /// Maps store information to a Store entity in the database
    /// </summary>
    /// <param name="storeLocation">The name of the location the store is in</param>
    /// <returns>A database-compatible Store entity</returns>
    public static ML.Store AppStoreToDbStore(
      string storeLocation)
    {
      ML.Store newStore = new()
      {
        StoreLocation = storeLocation
      };
      return newStore;
    }

    /// <summary>
    /// Maps order information to an Order entity in the database
    /// </summary>
    /// <param name="customerId">The customer ID the order was made by</param>
    /// <param name="storeId">The store ID the order was ordered from</param>
    /// <param name="orderCost">The cost of the whole order</param>
    /// <returns>A database-compatible Order entity</returns>
    public static ML.CustomerOrder AppOrderToDbOrder(
      int customerId, int storeId, decimal orderCost)
    {
      ML.CustomerOrder newOrder = new()
      {
        StoreId = storeId,
        CustomerId = customerId,
        OrderCost = orderCost,
        OrderDate = DateTime.Now
      };
      return newOrder;
    }

    /// <summary>
    /// Maps ordered item information to an Ordered Item entity in the database
    /// </summary>
    /// <param name="itemId">The ID of the ordered item</param>
    /// <param name="orderId">The ID of the order the item was ordered in</param>
    /// <param name="quantity">The quantity of the item ordered</param>
    /// <returns>A database-compatible Ordered Item entity</returns>
    public static ML.OrderedItem AppOrderedItemToDbOrderedItem(
      int itemId, int orderId, int quantity)
    {
      ML.OrderedItem newOrderedItem = new()
      {
        OrderId = orderId,
        ItemId = itemId,
        QuantityOrdered = quantity
      };
      return newOrderedItem;
    }

    /// <summary>
    /// Maps stored item information to an Stored Item entity in the database
    /// </summary>
    /// <param name="itemId">The ID of the item that's being stored</param>
    /// <param name="storeId">The ID of the store the item is being stored in</param>
    /// <param name="inStock">The quantity of the item stored in the store</param>
    /// <returns>A database-compatible Stored Item entity</returns>
    public static ML.StoredItem AppStoredItemToDbStoredItem(
      int itemId, int storeId, int inStock)
    {
      ML.StoredItem newStoredItem = new()
      {
        StoreId = storeId,
        ItemId = itemId,
        InStock = inStock
      };
      return newStoredItem;
    }
  }
}
