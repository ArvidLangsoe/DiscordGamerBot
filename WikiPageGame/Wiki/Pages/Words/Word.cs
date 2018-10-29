namespace WikiPageGame.Wiki.Pages.Words
{
    using System.Linq;

    public class Word
    {
        public static readonly char[] Seperators = new char[] { ' ', '\n', ',', '.', '(', ')', ';', ':' };

        public string Text { get; }

        public Word(string text)
        {
            if (!IsWord(text))
            {
                throw new NotAWordException();
            }
            Text = text;
        }

        public static bool IsWord(string text)
        {
            if (text == "")
                return false;

            if (Word.NumberOfWords(text) > 1)
                return false;

            return true;
        }

        public static Word[] ExtractAllWordsFrom(string text)
        {
            return text.Split(Word.Seperators).Where(a => a != "").Select(a => new Word(a)).ToArray();
        }

        public static int NumberOfWords(string text)
        {
            return text.Split(Word.Seperators).Length;
        }

        public string ToLowerCase()
        {
            return Text.ToLower();
        }

        public new string ToString => Text;
    }
}
