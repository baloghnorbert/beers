using Backend.Core.Modell.Request;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Modell.Entities
{
    public partial class BoilVolume
    {
        [JsonProperty("value")]
        [Required]
        public long? Value { get; set; }

        [JsonProperty("unit")]
        [Required]
        public string Unit { get; set; }
    }

    public partial class Method
    {
        [JsonProperty("mash_temp")]
        [Required]
        public MashTemp[] MashTemp { get; set; }

        [JsonProperty("fermentation")]
        [Required]
        public Fermentation Fermentation { get; set; }

        [JsonProperty("twist")]
        [Required]
        public object Twist { get; set; }
    }

    public partial class Fermentation
    {
        [JsonProperty("temp")]
        [Required]
        public BoilVolume Temp { get; set; }
    }

    public partial class MashTemp
    {
        [JsonProperty("temp")]
        [Required]
        public BoilVolume Temp { get; set; }

        [JsonProperty("duration")]
        [Required]
        public long? Duration { get; set; }
    }


    public class Beer : BeerRequest
    {
        [JsonProperty("id")]
        [Required]
        public long Id { get; set; }

        [JsonProperty("tagline")]
        [Required]
        public string Tagline { get; set; }

        [JsonProperty("first_brewed")]
        [Required]
        public string FirstBrewed { get; set; }

        [JsonProperty("abv")]
        public double? Abv { get; set; }

        [JsonProperty("ibu")]
        public long? Ibu { get; set; }

        [JsonProperty("target_fg")]
        public long? TargetFg { get; set; }

        [JsonProperty("target_og")]
        public long? TargetOg { get; set; }

        [JsonProperty("ebc")]
        public long? Ebc { get; set; }

        [JsonProperty("srm")]
        public long? Srm { get; set; }

        [JsonProperty("ph")]
        public double? Ph { get; set; }

        [JsonProperty("attenuation_level")]
        public long? AttenuationLevel { get; set; }

        [JsonProperty("volume")]
        [Required]
        public BoilVolume Volume { get; set; }

        [JsonProperty("boil_volume")]
        [Required]
        public BoilVolume BoilVolume { get; set; }

        [JsonProperty("method")]
        [Required]
        public Method Method { get; set; }

        public Beer()
        {
        }

        public Beer(string name, string image_url, string description) : base(name, image_url, description)
        {
        }

        public Beer(BeerRequest beer) : base(beer.Name, beer.ImageUrl, beer.Description)
        {
        }

        public Beer(BeerRequest beer, long id) : base(beer.Name, beer.ImageUrl, beer.Description)
        {
            Id = id;
        }
    }
}
