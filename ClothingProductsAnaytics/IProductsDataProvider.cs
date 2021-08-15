using ClothingProductsAnaytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingProductsAnaytics
{
    public interface IProductsDataProvider
    {
        IEnumerable<ProductData> GetProducts();
    }
}
