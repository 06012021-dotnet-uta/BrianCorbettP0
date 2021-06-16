using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class CheckoutPage : Page
  {
    private readonly BL.CustomerCart cart;
    private int confirmation;
    /// <summary>
    /// Represents whether the customer would like to finalize an order or cancel
    /// </summary>
    public int Confirmation { get; set; }

    /// <summary>
    /// Initializes the page heading and the data that belongs on the page
    /// </summary>
    /// <param name="cart">The logged-in customer's cart object</param>
    public CheckoutPage(BL.CustomerCart cart) : base()
    {
      this.cart = cart;
      ManualInitializePageHeading("Checkout", "Review the items in your cart\n" +
        "Press 1 to place the order, -1 to keep shopping, anything else to cancel the order");
      ManualInitializeOptionsList(cart.DetailsToString());
    }

    /// <summary>
    /// Displays checkout page data and stores confirmation of the customer
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      UserInteract.PutLine($"\nCart total: ${cart.CartTotal}");
      Confirmation = UserInteract.GetInteger();
    }
  }
}
