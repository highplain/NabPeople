using System;

namespace NabPeople.Reader
{
    public class PeopleReaderException : Exception
    {
        public PeopleReaderException() { }
        public PeopleReaderException(string message) : base(message) { }
        public PeopleReaderException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
