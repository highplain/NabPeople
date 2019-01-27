using System;
using NabPeople.Dal.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using NabPeople.Dal.Repository;
using System.Threading.Tasks;

namespace NabPeople.Reader
{
    public class PeopleReader
    {
        // Path to the data file at runtime.
        const string dataFileName = @"\Data\Pet.json";

        public async Task<List<Person>> GetPeopleList()
        {
            // Get the json text from the file.
            string jsonString = await GetJsonText();

            // Return a person list.
            return GetPeopleListFromJsonFile(jsonString);
        }

        // Unit Test.
        // Does not use any external resources.
        public List<Person> GetPeopleListFromJsonFile(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                throw new ArgumentException("Json string is empty.");
            }
            
            try
            {
                List<Person> people = new List<Person>();
                people = JsonConvert.DeserializeObject<List<Person>>(jsonString);
                return people;
            }
            catch (Exception ex)
            {
                throw new PeopleReaderException("Error reading the data file.", ex);
            }
        }

        private async Task<string> GetJsonText()
        {
            try
            {
                string fullDataFilePath = AppDomain.CurrentDomain.BaseDirectory + dataFileName;
                PeopleRepository repo = new PeopleRepository();
                string jsonString = await repo.GetJsonTextFromFile(fullDataFilePath);
                return jsonString;
            }
            catch (PeopleDalException ex)
            {
                throw new PeopleReaderException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new PeopleReaderException("Unexpected error getting json text.", ex);
            }
        }


    }
}
