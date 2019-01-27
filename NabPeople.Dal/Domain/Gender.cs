using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NabPeople.Dal.Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        Male,
        Female
    }
}
