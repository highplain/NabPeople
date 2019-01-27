using System;
using System.Collections.Generic;
using System.Text;

namespace NabPeople.Dal.Repository
{
    public class PeopleDalException : Exception
    {
        public PeopleDalException() { }
        public PeopleDalException(string message) : base(message) { }
        public PeopleDalException(string message, Exception innerException)
        : base(message, innerException) { }

    }
}
