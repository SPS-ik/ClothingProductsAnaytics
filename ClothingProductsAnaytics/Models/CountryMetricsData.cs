using System;
using System.Text.Json.Serialization;

namespace ClothingProductsAnaytics.Models
{
    public class CountryMetricsData
    {
        [JsonPropertyName("origin_country")]
        public string OriginCountry { get; set; }

        [JsonPropertyName("price")]
        public double? AveragePrice { get; set; }

        [JsonPropertyName("five_percentage")]
        public int? FivePercentage { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CountryMetricsData data &&
                   string.Equals(OriginCountry, data.OriginCountry, StringComparison.OrdinalIgnoreCase) &&
                   FivePercentage == data.FivePercentage &&
                   AveragePrice == data.AveragePrice;
        }
    }
}
