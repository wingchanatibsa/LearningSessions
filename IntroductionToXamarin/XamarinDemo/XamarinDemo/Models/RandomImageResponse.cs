using System;
using Newtonsoft.Json;

namespace XamarinDemo.Models
{
    public class RandomImageResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
