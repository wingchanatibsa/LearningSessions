using System;
using Newtonsoft.Json;

namespace XamarinDemo.Models
{
    public class BreedsListResponse
    {
        [JsonProperty("message")]
        public object Message { get; set; }
    }
}
