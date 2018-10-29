namespace WikiPageGameUnitTests.Wiki.Pages
{
    using WikiPageGame.Wiki.Pages;

    internal class WikiPageStub : IWikiPage
    {
        public string Link => "Some Link";

        public string Title => "Albert Einstein";

        public string Text => "Albert Einstein was a man. Albert Einstein was a brilliant man";
    }
}
