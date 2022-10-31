using LKenselaar.CloudDatabases.Models.Interfaces;
using Newtonsoft.Json;

namespace LKenselaar.CloudDatabases.Models
{
    public abstract class Entity : IEntity
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }
    }
}
