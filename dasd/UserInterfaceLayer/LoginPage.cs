using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class LoginPage : Page
  {
    private string userName;
    public string UserName { get; set; }
    private string passWord;
    public string PassWord { get; set; }

    public LoginPage() : base()
    {
      ManualInitializePageHeading("Login", "Type your username and password");
    }

    public void ShowPage()
    {
      base.ShowPage();
      UserName = UserInteract.GetString("Username => ");
      PassWord = UserInteract.GetString("Password => ");
    }
  }
}
