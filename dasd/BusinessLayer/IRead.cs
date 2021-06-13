namespace BusinessLayer
{
  public interface IRead
  {
    int GetInteger(string prompt = "=> ");
    string GetString(string prompt = "=> ");
  }
}