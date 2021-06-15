using System;
using ML = ModelsLayer;

namespace BusinessLayer
{
  public static class MapperClassAppToDb
  {
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

    public static ML.Store AppStoreToDbStore(
      string storeLocation)
    {
      ML.Store newStore = new()
      {
        StoreLocation = storeLocation
      };
      return newStore;
    }

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
