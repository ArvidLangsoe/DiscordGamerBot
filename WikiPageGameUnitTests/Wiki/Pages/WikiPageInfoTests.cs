namespace WikiPageGameUnitTests.Wiki.Pages
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using WikiPageGame.Wiki.Pages;
    using WikiPageGame.Wiki.Pages.Words;

    [TestClass()]
    public class WikiPageInfoTests
    {
        internal WikiPageInfo Info;

        [TestInitialize()]
        public void Setup()
        {
            IWikiPage testPage = new WikiPageStub();
            Info = new WikiPageInfo(testPage);
        }

        [TestMethod()]
        public void GivenWikiPage_WhenGettingStatictics_ThenVariousCountsAreCorrect()
        {
            var statistics = Info.GetStatistics();
            var dict = statistics.ToDictionary(a => a.Word);
            Assert.AreEqual(dict["albert"].Count, 2);
            Assert.AreEqual(dict["einstein"].Count, 2);
            Assert.AreEqual(dict["brilliant"].Count, 1);
        }

        [TestMethod()]
        public void GivenWikiPage_WhenCheckingIfItemsAreContained_ThenCorrectItemsAreContained()
        {
            Assert.IsTrue(Info.Contains("albert"));
            Assert.IsTrue(Info.Contains(new Word("einstein")));
            Assert.IsFalse(Info.Contains(new Word("newton")));
        }

        [TestMethod()]
        public void GivenWikiPage_WhenWordIsPassed_ThenTitleContainsWordsIsCorrect()
        {
            Assert.IsTrue(Info.TitleContainsWord("albert"));
            Assert.IsTrue(Info.TitleContainsWord("EINSTEIN"));
            Assert.IsTrue(Info.TitleContainsWord(new Word("Albert")));
            Assert.IsTrue(Info.TitleContainsWord(new Word("einstein")));
            Assert.IsTrue(Info.TitleContainsWord(new Word("Einstein")));
            Assert.IsFalse(Info.TitleContainsWord(new Word("man")));
        }

        [TestMethod()]
        public void GivenWikiPage_WhenGetStatisticIsCalledWithValidWord_ThenReturnCorrectWordStatistic()
        {
            string[] testWordsAndCount = new string[] { "albert:2", "EINSTEIN:2", "brilliant:1" };


            foreach (string word in testWordsAndCount)
            {
                string[] wordSplit = word.Split(':');
                var statistic = Info.GetStatisticOf(wordSplit[0]);

                Assert.AreEqual(statistic.Count, int.Parse(wordSplit[1]));
            }
        }

        [TestMethod()]
        public void GivenWikiPage_WhenGetStatisticIsCalledWithInValidWord_ThenReturnNull()
        {
            Assert.IsNull(Info.GetStatisticOf("newton"));
        }
    }
}
