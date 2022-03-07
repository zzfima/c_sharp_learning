using Newtonsoft.Json;
using System;

namespace SavedTimesCosmos
{
    public class SavedTimeEntity
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }
        [JsonProperty(PropertyName = "partitionKey")] public string PartitionKey { get; set; }

        public DateTime SavedTime { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}