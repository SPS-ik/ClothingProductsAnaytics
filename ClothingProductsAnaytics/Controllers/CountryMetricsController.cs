using ClothingProductsAnaytics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingProductsAnaytics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryMetricsController : ControllerBase
    {
        private readonly IProductsDataProvider _productsDataProvider;

        public CountryMetricsController(IProductsDataProvider productsDataProvider)
        {
            _productsDataProvider = productsDataProvider;
        }

        [HttpGet]
        public IEnumerable<CountryMetricsData> Get()
        {
            var productsData = _productsDataProvider.GetProducts();


            var allCountriesMetrics = productsData.GroupBy(p => p.OriginCountry)
                        .Select(g =>
                        {
                            var countryData = new CountryMetricsData
                            {
                                OriginCountry = g.Key,
                                AveragePrice = g.Average(p => p.Price)
                            };

                            var ratings = g.Sum(p => p.RatingCount);

                            var fiveRatings = g.Sum(p => p.RatingFiveCount);

                            countryData.FivePercentage = ratings != null && ratings != 0
                                ? fiveRatings * 100 / ratings
                                : 0;

                            return countryData;
                        })
                        .OrderBy(p => p.OriginCountry);

            return allCountriesMetrics;
        }
    }
}
