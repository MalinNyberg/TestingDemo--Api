using System.Text.Json.Serialization;

namespace TestingRepApiDemo.Models.Dtos
{
    public class DogPicturesDto
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
       
    }
}
