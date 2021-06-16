using System;
using DB = P0DbContext;
using BL = BusinessLayer;
using UI = UserInterfaceLayer;
using ML = ModelsLayer;

namespace P0
{
  class Program
  {
    static void Main(string[] args)
    {
      DB.P0DbContext context = new();
      BL.CustomerCart Cart;
      int IntMenuChoice;
      string StoreChoice;
      string FocusStore;
      int IntItemChoice;
      int CustomerId;
      int StoreId;

    Landing:
      UI.LandingPage LandPage = new();
      LandPage.ShowPage();
      IntMenuChoice = LandPage.MenuChoice;
      switch (IntMenuChoice)
      {
        case 1:
          goto Login;
        case 2:
          goto Signup;
        case 3:
          goto Quit;
        default:
          goto Landing;
      }
    Login:
      UI.LoginPage LoginPage = new();
      LoginPage.ShowPage();
      string Username = LoginPage.UserName;
      string Password = LoginPage.PassWord;
      bool LoginValidationSuccessful = BL.DBValidation.ValidateLogin(Username, Password);
      CustomerId = BL.DBInteract.GetCustomerId(Username, Password);
      switch (LoginValidationSuccessful)
      {
        case true:
          Cart = new(CustomerId);
          goto Home;
        case false:
          goto Landing;
      }
    Signup:
      UI.SignupPage SignupPage = new();
      SignupPage.ShowPage();
      bool SignupValidationSuccessful = BL.DBValidation.ValidateSignup(SignupPage.UserName);
      switch (SignupValidationSuccessful)
      {
        case true:
          string firstName = SignupPage.FirstName;
          string lastName = SignupPage.LastName;
          string userName = SignupPage.UserName;
          string passWord = SignupPage.PassWord;
          ML.Customer newCustomer = BL.MapperClassAppToDb.AppCustomerToDbCustomer(firstName, lastName, userName, passWord);
          context.Customers.Add(newCustomer);
          context.SaveChanges();
          goto Login;
        case false:
          goto Signup;
      }
    Home:
      UI.HomePage HomePage = new();
      HomePage.ShowPage();
      IntMenuChoice = HomePage.MenuChoice;
      switch (IntMenuChoice)
      {
        case 1:
          goto ChooseStore;
        case 2:
          goto OrderHistory;
        case 3:
          goto CustomerSearch;
        case 4:
          goto Landing;
        default:
          goto Home;
      }
    ChooseStore:
      UI.ChooseStorePage ChooseStorePage = new();
      ChooseStorePage.ShowPage();
      StoreChoice = ChooseStorePage.StoreChoice;
      goto StoreOptions;
    StoreOptions:
      UI.StoreOptionsPage StoreOptionsPage = new(StoreChoice);
      StoreOptionsPage.ShowPage();
      FocusStore = StoreOptionsPage.FocusStore;
      IntMenuChoice = StoreOptionsPage.MenuChoice;
      switch (IntMenuChoice)
      {
        case 1:
          goto StoreInventory;
        case 2:
          goto StoreOrderHistory;
        case 3:
          goto Home;
        default:
          goto StoreOptions;
      }
    StoreInventory:
      UI.StoreInventoryPage StoreInventoryPage = new(FocusStore);
      StoreInventoryPage.ShowPage();
      IntItemChoice = StoreInventoryPage.MenuChoice;
      switch (IntItemChoice < 0)
      {
        case false:
          int DesiredQuantity = StoreInventoryPage.DesiredQuantity;
          int ItemId = IntItemChoice + 1000;
          bool QuantityValidationSuccessful =
            BL.DBValidation.ValidateQuantity(ItemId, FocusStore, DesiredQuantity);
          if (QuantityValidationSuccessful)
          {
            StoreId = StoreInventoryPage.StoreId;
            Cart.AddToCart(ItemId, StoreId, DesiredQuantity);
          }
          goto StoreInventory;
        case true:
          goto Checkout;
      }
    Checkout:
      UI.CheckoutPage CheckoutPage = new(Cart);
      CheckoutPage.ShowPage();
      int Confirmation = CheckoutPage.Confirmation;
      switch (Confirmation)
      {
        case 1:
          StoreId = BL.DBInteract.GetStoreId(FocusStore);
          ML.CustomerOrder NewOrder =
            BL.MapperClassAppToDb.AppOrderToDbOrder(CustomerId, StoreId, Cart.CartTotal);
          context.CustomerOrders.Add(NewOrder);
          context.SaveChanges();
          foreach (var cartItem in Cart.InCartItems)
          {
            int ItemId = cartItem[1];
            int Quantity = cartItem[3];
            BL.DBInteract.DecreaseInStock(ItemId, StoreId, Quantity);
            ML.OrderedItem NewOrderedItem =
              BL.MapperClassAppToDb.AppOrderedItemToDbOrderedItem(ItemId, NewOrder.OrderId, Quantity);
            context.OrderedItems.Add(NewOrderedItem);
          }
          context.SaveChanges();
          Cart.ClearAll();
          goto Home;
        case -1:
          goto StoreInventory;
        default:
          Cart.ClearAll();
          goto Home;
      }
    StoreOrderHistory:
      StoreId = BL.DBInteract.GetStoreId(FocusStore);
      UI.OrderHistoryPage StoreOrderHistoryPage = new(storeId: StoreId);
      StoreOrderHistoryPage.ShowPage();
      goto Home;
    OrderHistory:
      UI.OrderHistoryPage OrderHistoryPage = new(customerId: CustomerId);
      OrderHistoryPage.ShowPage();
      goto Home;
    CustomerSearch:
      UI.CustomerSearchPage CustomerSearchPage = new();
      CustomerSearchPage.ShowPage();
      goto Home;
    Quit:
      Console.WriteLine("Thanks for being a loyal customer at Golfs-a-lot!");
    }
  }
}
