using NUnit.Framework;
using ClothingProductsAnaytics.Controllers;
using ClothingProductsAnaytics;
using System.Collections.Generic;
using ClothingProductsAnaytics.Models;

namespace ClothingProductsAnalyticsTest
{
    public class CountryMetricsControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCountryMetricsTest()
        {
            var countryController = new CountryMetricsController(new FakeProductsProvider());

            var countryMetrics = countryController.Get();

            var expectedMetrics = new List<CountryMetricsData>
            {
                new CountryMetricsData
                {
                    OriginCountry = "US",
                    AveragePrice = 15,
                    FivePercentage = 50
                },
                new CountryMetricsData
                {
                    OriginCountry = "FR",
                    AveragePrice = 10.5,
                    FivePercentage = 0
                },
                new CountryMetricsData
                {
                    OriginCountry = "UA",
                    AveragePrice = 125,
                    FivePercentage = 75
                }
            };

            CollectionAssert.AreEquivalent(expectedMetrics, countryMetrics);
        }
    }

    public class FakeProductsProvider : IProductsDataProvider
    {
        public IEnumerable<ProductData> GetProducts()
        {
            var products = new List<ProductData>
            {
                new ProductData
                {
                    OriginCountry = "US",
                    Price = 10,
                    RatingCount = 4,
                    RatingFiveCount = 2
                },
                new ProductData
                {
                    OriginCountry = "US",
                    Price = 15,
                    RatingCount = 7,
                    RatingFiveCount = 3
                },
                new ProductData
                {
                    OriginCountry = "US",
                    Price = 20,
                    RatingCount = 3,
                    RatingFiveCount = 2
                },
                new ProductData
                {
                    OriginCountry = "FR",
                    Price = 11,
                    RatingCount = 0,
                    RatingFiveCount = 0
                },
                new ProductData
                {
                    OriginCountry = "FR",
                    Price = 10,
                    RatingCount = 0,
                    RatingFiveCount = 0
                },
                new ProductData
                {
                    OriginCountry = "UA",
                    Price = 100,
                    RatingCount = 7,
                    RatingFiveCount = 5
                },
                new ProductData
                {
                    OriginCountry = "UA",
                    Price = 150,
                    RatingCount = 5,
                    RatingFiveCount = 4
                },
            };

            return products;
        }
    }
}