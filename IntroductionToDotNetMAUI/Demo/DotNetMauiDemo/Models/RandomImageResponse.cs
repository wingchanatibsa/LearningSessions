using System;
namespace DotNetMauiDemo.Models
{
    public class RandomImageResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

