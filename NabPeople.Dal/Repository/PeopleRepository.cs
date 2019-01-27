using System;
using System.IO;
using System.Threading.Tasks;

namespace NabPeople.Dal.Repository
{
    public class PeopleRepository
    {
        // Integration test.
        // Calls to an external resource.
        public async Task<string> GetJsonTextFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException("File not found.");
            }

            string jsonText = string.Empty;
            try
            {
                jsonText = await File.ReadAllTextAsync(filePath);
            }
            catch (Exception ex)
            {
                throw new PeopleDalException("Error reading json file.", ex);
            }
            return jsonText;

        }

        
    }
}
