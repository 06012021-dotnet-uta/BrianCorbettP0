using System.Collections.Generic;
using System;
namespace P0
{
    public abstract class Page
    {
        private string name;
        public string Name { get; set; }
        private PageHeading pageHeading;
        private Menu menu;
        private string toPage;
        public string ToPage { get; set; }

        public Page() { }
        public Page(string title, string prompt)
        {
            this.pageHeading = new PageHeading(title, prompt);
        }
        public Page(string title, string prompt, List<string> options, Type type)
        {
            this.pageHeading = new PageHeading(title, prompt);
            this.menu = new Menu(options, type);
        }

        protected void ManualInitializePageHeading(string title, string prompt)
        {
            pageHeading = new PageHeading(title, prompt);
        }
        protected void ManualInitializeOptionsList(List<string> options, Type type)
        {
            menu = new Menu(options, type);
        }

        public void LoadPage()
        {
            Console.Clear();
        }
        public void ShowPage()
        {
            LoadPage();
            pageHeading.Display();
            if (menu != null) ToPage = menu.MenuLoop();
        }
    }
}