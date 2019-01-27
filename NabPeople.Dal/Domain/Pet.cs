using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace NabPeople.Dal.Domain
{
    public class Pet
    {
        public string Name { get; set; }

        [JsonProperty("type")]
        public PetType PetType { get; set; }


    }
}
