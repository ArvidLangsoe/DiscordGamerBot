namespace WikiPageGame.Wiki.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using WikiPageGame.Wiki.Pages.Words;

    public class WikiPageInfo
    {
        private Dictionary<string, WordStatistic> WordStatistics;

        public string Title { get; }

        public string Link { get; }

        private Word[] titleWords;

        public WikiPageInfo(IWikiPage page)
        {
            Title = page.Title;
            titleWords = Word.ExtractAllWordsFrom(Title);
            Link = page.Link;
            WordStatistics = new Dictionary<string, WordStatistic>();
            GenerateWordCount(page.Text);
        }

        public List<WordStatistic> GetStatistics()
        {
            return WordStatistics.Values.ToList();
        }

        public bool Contains(string word)
        {
            return this.Contains(new Word(word));
        }

        public bool Contains(Word word)
        {
            return WordStatistics.ContainsKey(word.ToLowerCase());
        }

        public bool TitleContainsWord(string word)
        {
            return this.TitleContainsWord(new Word(word));
        }

        public bool TitleContainsWord(Word word)
        {
            return titleWords.Any(a => a.ToLowerCase() == word.ToLowerCase());
        }

        public WordStatistic GetStatisticOf(string word)
        {

            return this.GetStatisticOf(new Word(word));
        }

        public WordStatistic GetStatisticOf(Word word)
        {
            try
            {
                return WordStatistics[word.ToLowerCase()];
            }
            catch (KeyNotFoundException e)
            {
                return null;
            }
        }

        private void GenerateWordCount(string text)
        {
            Word[] words = Word.ExtractAllWordsFrom(text);
            foreach (Word word in words)
            {
                IncreaseCountOf(word.ToLowerCase());
            }
        }

        private void IncreaseCountOf(string word)
        {
            WordStatistic statistic = RetrieveUniqueStatistic(word);
            statistic.IncreaseCount();
            WordStatistics[word] = statistic;
        }

        private WordStatistic RetrieveUniqueStatistic(string word)
        {
            if (WordStatistics.ContainsKey(word))
                return WordStatistics[word];
            else
                return new WordStatistic() { Word = word };
        }
    }
}
