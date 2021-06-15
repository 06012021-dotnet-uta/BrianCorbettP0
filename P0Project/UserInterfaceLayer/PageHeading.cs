using BusinessLayer;

namespace UserInterfaceLayer
{
    public class PageHeading : Write
    {
        private readonly string pageTitle;
        private readonly string pagePrompt;

        public PageHeading(string pageTitle, string pagePrompt)
        {
            this.pageTitle = pageTitle;
            this.pagePrompt = pagePrompt;
        }

        public void Display()
        {
            PutLine($"{pageTitle}");
            PutLine($"{pagePrompt}");
            PutLine($"~~~~~~~~~~");
        }
    }
}