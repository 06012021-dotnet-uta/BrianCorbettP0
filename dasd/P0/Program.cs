using System.Collections.Generic;
using System;
using System.Linq;
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

    Landing:
      UI.LandingPage LandPage = new();
      LandPage.ShowPage();
      int IntMenuChoice = LandPage.MenuChoice;
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
      bool LoginValidationSuccessful = BL.DBValidation.ValidateLogin(LoginPage.UserName, LoginPage.PassWord);
      switch (LoginValidationSuccessful)
      {
        case true:
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
      }
    ChooseStore:
      UI.ChooseStorePage ChooseStorePage = new();
      ChooseStorePage.ShowPage();
      string StoreChoice = ChooseStorePage.StoreChoice;
      goto StoreOptions;
    StoreOptions:
      UI.StoreOptionsPage StoreOptionsPage = new(StoreChoice);
      StoreOptionsPage.ShowPage();
      string FocusStore = StoreOptionsPage.FocusStore;
      IntMenuChoice = StoreOptionsPage.MenuChoice;
      switch (IntMenuChoice)
      {
        case 1:
          goto StoreInventory;
        case 2:
          goto StoreOrderHistory;
      }
    StoreInventory:
      UI.StoreInventoryPage StoreInventoryPage = new(FocusStore);
      StoreInventoryPage.ShowPage();
      int ItemChoice = StoreInventoryPage.MenuChoice;
      // enter into user's cart to select number of items
    StoreOrderHistory:
    OrderHistory:
    CustomerSearch:
    Quit:
      Console.WriteLine("QUIT");
    }
  }
}
