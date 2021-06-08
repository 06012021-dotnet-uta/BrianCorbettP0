namespace P0
{
    public class LogIn
    {
        public void LoginUser()
        {
            UserInteract userInteract = new UserInteract();
            userInteract.TakeLine(typeof(int));
        }
    }
}