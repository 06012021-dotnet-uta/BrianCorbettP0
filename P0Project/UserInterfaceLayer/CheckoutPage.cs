using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class CheckoutPage : Page
  {
    private readonly BL.CustomerCart cart;
    private int confirmation;
    public int Confirmation { get; }

    public CheckoutPage(BL.CustomerCart cart) : base()
    {
      this.cart = cart;
      ManualInitializePageHeading("Checkout", "Review the items in your cart\n" +
        "Enter 1 to place the order, enter anything else to cancel the order");
      ManualInitializeOptionsList(cart.DetailsToString());
    }

    public void ShowPage()
    {
      base.ShowPage();
      UserInteract.PutLine($"\nCart total: ${cart.CartTotal}");
      confirmation = UserInteract.GetInteger();
    }
  }
}
