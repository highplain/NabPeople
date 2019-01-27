using System;

namespace NabPeople.Reader
{
    public class PeopleReportException : Exception
    {
        public PeopleReportException() { }
        public PeopleReportException(string message) : base(message) { }
        public PeopleReportException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
