namespace UserInterfaceLayer
{
  public class SignupPage : Page
  {
    private string firstName;
    public string FirstName { get; }
    private string lastName;
    public string LastName { get; }
    private string userName;
    public string UserName { get; }
    private string passWord;
    public string PassWord  { get; }

    public SignupPage() : base()
    {
      ManualInitializePageHeading("Signup", "Fill out the following information");
    }

    public void ShowPage()
    {
      base.ShowPage();
      firstName = UserInteract.GetString("First name => ");
      lastName = UserInteract.GetString("Last name => ");
      userName = UserInteract.GetString("Username => ");
      passWord = UserInteract.GetString("Password => ");
    }
  }
}
