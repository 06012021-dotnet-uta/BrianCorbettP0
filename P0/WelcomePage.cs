using System.Collections.Generic;

namespace P0
{
    public class WelcomePage : Page
    {
        public WelcomePage() : base()
        {
            Name = "Welcome";
            ManualInitializePageHeading("Welcome to #STORE", "Login if you have account, signup if you don't.");
            ManualInitializeOptionsList(new List<string>() { "Login", "Signup" }, MenuInputType.TypeInteger());
        }
    }
}