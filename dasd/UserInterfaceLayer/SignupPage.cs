using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = BusinessLayer;

namespace UserInterfaceLayer
{
  public class SignupPage : Page
  {
    private string firstName;
    public string FirstName { get; set; }
    private string lastName;
    public string LastName { get; set; }
    private string userName;
    public string UserName { get; set; }
    private string passWord;
    public string PassWord { get; set; }


    public SignupPage() : base()
    {
      ManualInitializePageHeading("Signup", "Fill out the following information");
    }

    public void ShowPage()
    {
      base.ShowPage();
      FirstName = UserInteract.GetString("First name => ");
      LastName = UserInteract.GetString("Last name => ");
      UserName = UserInteract.GetString("Username => ");
      PassWord = UserInteract.GetString("Password => ");
    }
  }
}
