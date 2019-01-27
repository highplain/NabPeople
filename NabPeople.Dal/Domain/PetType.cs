using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace NabPeople.Dal.Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PetType
    {
        Cat,
        Dog,
        Fish
    }
}
