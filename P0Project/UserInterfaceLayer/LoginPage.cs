namespace UserInterfaceLayer
{
  public class LoginPage : Page
  {
    private string userName;
    public string UserName { get; }
    private string passWord;
    public string PassWord { get; }

    public LoginPage() : base()
    {
      ManualInitializePageHeading("Login", "Type your username and password");
    }

    public void ShowPage()
    {
      base.ShowPage();
      userName = UserInteract.GetString("Username => ");
      passWord = UserInteract.GetString("Password => ");
    }
  }
}
