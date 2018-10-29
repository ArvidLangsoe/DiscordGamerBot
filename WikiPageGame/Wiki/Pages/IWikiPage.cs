namespace WikiPageGame.Wiki.Pages
{
    public interface IWikiPage
    {
        string Link { get; }

        string Title { get; }

        string Text { get; }
    }
}
