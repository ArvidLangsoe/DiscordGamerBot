namespace WikiPageGame.Wiki.Pages.Words
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotAWordException : Exception
    {
        public NotAWordException()
        {
        }

        public NotAWordException(string message) : base(message)
        {
        }

        public NotAWordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAWordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
