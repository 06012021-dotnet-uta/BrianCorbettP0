namespace UserInterfaceLayer
{
  public class LoginPage : Page
  {
    private string userName;
    /// <summary>
    /// Represents the username of the customer
    /// </summary>
    public string UserName { get; set; }
    private string passWord;
    /// <summary>
    /// Represents the password of the customer
    /// </summary>
    public string PassWord { get; set; }

    /// <summary>
    /// Initializes the page heading that belongs on the page
    /// </summary>
    public LoginPage() : base()
    {
      ManualInitializePageHeading("Login", "Type your username and password");
    }

    /// <summary>
    /// Displays login page data and stores username and password of the customer
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      UserName = UserInteract.GetString("Username => ").Trim();
      PassWord = UserInteract.GetString("Password => ");
    }
  }
}
