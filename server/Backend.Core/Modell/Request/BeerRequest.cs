using Newtonsoft.Json;

namespace Backend.Core.Modell.Request
{
    public class BeerRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        public BeerRequest()
        {
        }

        public BeerRequest(string name, string image_url, string description)
        {
            this.Name = name;
            this.ImageUrl = image_url;
            this.Description = description;
        }
    }
}
