using Entities.Models;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.EfCore.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilterProducts(this IQueryable<Product> products,
           uint minPrice, uint maxPrice) =>
        products.Where(products =>
            products.Price >= minPrice &&
           products.Price <= maxPrice);

        public static IQueryable<Product> Search(this IQueryable<Product> products,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return products
                    .Where(p => p.ProductName
                    .ToLower()
                    .Contains(searchTerm));
        }
        public static IQueryable<Product> Sort(this IQueryable<Product> products,
          string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(p =>p.ProductId );

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Product>(orderByQueryString);

            if (orderQuery is null)
                return products.OrderBy(p =>p.ProductId);

            return products.OrderBy(orderQuery);
        }
    }
    
}
