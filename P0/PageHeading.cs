namespace P0
{
    public class PageHeading : Write
    {
        private string pageTitle;
        public string PageTitle { get; set; }
        private string pagePrompt;
        public string PagePrompt { get; set; }

        public PageHeading(string pageTitle, string pagePrompt)
        {
            this.pageTitle = pageTitle;
            this.pagePrompt = pagePrompt;
        }

        public void Display()
        {
            PutLine($"{this.pageTitle}");
            PutLine($"{this.pagePrompt}");
            PutLine($"~~~~~~~~~~");
        }
    }
}