using System;
using Xunit;
using Xunit.Abstractions;

using NabPeople.Dal.Domain;
using System.Collections.Generic;

namespace NabPeople.Reader.Tests
{
    public class GetPeopleListShould : IClassFixture<PeopleListFixture>
    {
        PeopleReader _reader;
        ITestOutputHelper _output;
        private readonly PeopleListFixture _peopleListFixture;

        public GetPeopleListShould(PeopleListFixture peopleListFixture, ITestOutputHelper output)
        {
            _output = output;
            _peopleListFixture = peopleListFixture;
            
            _reader = new PeopleReader();
            _output.WriteLine("PeopleReader created.");

        }

        [Fact]
        public void ReturnACorrectResultForAValidInput()
        {
            string testJsonString = _peopleListFixture.ValidJsonData;
            List<Person> people = _reader.GetPeopleListFromJsonFile(testJsonString);
            Assert.Equal(3,people.Count);
        }

        [Fact]
        public void ThrowsAPeopleReaderExceptionForInvalidInput()
        {
            string testJsonString = _peopleListFixture.InvalidJsonData;
            Assert.Throws<PeopleReaderException>(() => _reader.GetPeopleListFromJsonFile(testJsonString));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowsAnArgumentExceptionForANullParameter(string jsonString)
        {
            Assert.Throws<ArgumentException>(() => _reader.GetPeopleListFromJsonFile(jsonString));
        }


        


    }
}
