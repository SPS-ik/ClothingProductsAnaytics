using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingProductsAnaytics.Models
{
    public class ProductData
    {
        [Name("origin_country")]
        public string OriginCountry { get; set; }

        [Name("price")]
        public double? Price { get; set; }

        [Name("rating_count")]
        public int? RatingCount { get; set; }

        [Name("rating_five_count")]
        public int? RatingFiveCount { get; set; }
    }
}
