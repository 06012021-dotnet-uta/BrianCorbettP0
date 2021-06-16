using BusinessLayer;

namespace UserInterfaceLayer
{
  public class PageHeading : Write
  {
    private readonly string pageTitle;
    private readonly string pagePrompt;

    /// <summary>
    /// Defines the page title and prompt
    /// </summary>
    /// <param name="pageTitle">Title of the page</param>
    /// <param name="pagePrompt">A prompt for the customer</param>
    public PageHeading(string pageTitle, string pagePrompt)
    {
      this.pageTitle = pageTitle;
      this.pagePrompt = pagePrompt;
    }

    /// <summary>
    /// Displays the page heading
    /// </summary>
    public void Display()
    {
      PutLine($"{pageTitle}");
      PutLine($"{pagePrompt}");
      PutLine($"~~~~~~~~~~");
    }
  }
}