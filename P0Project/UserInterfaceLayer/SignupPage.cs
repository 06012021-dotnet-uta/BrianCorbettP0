using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class SignupPage : Page
  {
    private string firstName;
    /// <summary>
    /// Represents the first name of the new customer
    /// </summary>
    public string FirstName { get; set; }
    private string lastName;
    /// <summary>
    /// Represents the last name of the new customer
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Represents the username of the new customer
    /// </summary>
    private string userName;
    public string UserName { get; set; }
    private string passWord;
    /// <summary>
    /// Represents the password of the new customer
    /// </summary>
    public string PassWord  { get; set; }

    /// <summary>
    /// Initializes the page heading the belongs on the page
    /// </summary>
    public SignupPage() : base()
    {
      ManualInitializePageHeading("Signup", "Fill out the following information");
    }

    /// <summary>
    /// Displays login page data and stores first and last name,
    /// username, and password of the customer
    /// </summary>
    public void ShowPage()
    {
      base.ShowPage();
      BL.Write write = new();
      BL.Read read = new();
      FirstName = write.Capitalize(UserInteract.GetString("First name => ")).Trim();
      LastName = write.Capitalize(UserInteract.GetString("Last name => ")).Trim();
      UserName = read.CleanInput(UserInteract.GetString("Username => ").Trim(), @"[ ]");
      PassWord = UserInteract.GetString("Password => ");
    }
  }
}
