namespace WikiPageGameUnitTests.Wiki.Pages.Words
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WikiPageGame.Wiki.Pages.Words;

    [TestClass()]
    public class WordTests
    {
        [TestMethod()]
        public void WhenConstructingCorrectWords_ThenNoException()
        {
            new Word("Albert");
            new Word("1994ad");
            new Word("<?^*|");
        }

        [TestMethod()]
        public void GivenSomeIncorrectWords_ThenIsWordReturnsFalse()
        {
            Assert.IsFalse(Word.IsWord(""));
            Assert.IsFalse(Word.IsWord("."));
            Assert.IsFalse(Word.IsWord("word word"));
            Assert.IsFalse(Word.IsWord("word;word"));
            Assert.IsFalse(Word.IsWord("word\nword"));
            Assert.IsFalse(Word.IsWord("word,word"));
            Assert.IsFalse(Word.IsWord("word.word"));
            Assert.IsFalse(Word.IsWord("word:word"));
            Assert.IsFalse(Word.IsWord("word(word"));
            Assert.IsFalse(Word.IsWord("word)word"));
        }

        [TestMethod()]
        public void GivenASentence_ThenExtractAllWordsReturnsTheCorrectNumberOfWords()
        {
            Assert.AreEqual(8, Word.ExtractAllWordsFrom("Albert Eistein is cool yo. He's awesome yo.").Length);
        }
    }
}
