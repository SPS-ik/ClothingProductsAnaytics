using ClothingProductsAnaytics.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingProductsAnaytics
{
    public class ProductsDataProvider : IProductsDataProvider
    {
        public IEnumerable<ProductData> GetProducts()
        {
            try
            {
                var products = GetProductsFromCsv("test-task_dataset_summer_products.csv");

                return products;
            }
            catch
            {

            }

            return null;
        }

        private IEnumerable<ProductData> GetProductsFromCsv(string fileName)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null,
                };

                using (var reader = new StreamReader(fileName))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<ProductData>().ToList();
                    return records;
                }
            }
            catch
            {

            }

            return null;
        }
    }
}
