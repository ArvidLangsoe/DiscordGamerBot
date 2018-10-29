namespace WikiPageGame.Wiki.Pages.Words
{
    public class WordStatistic
    {
        public string Word { get; set; }

        public int Count { get; private set; }

        public WordStatistic()
        {
        }

        public void IncreaseCount()
        {
            Count += 1;
        }
    }
}
