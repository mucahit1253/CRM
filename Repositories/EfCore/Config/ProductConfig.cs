using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName);
            builder.Property(p => p.Price);
            builder.HasData
                (
                new Product { ProductId=1,ProductName="Ürün1",Price=100},
                new Product { ProductId = 2, ProductName = "Ürün2", Price = 200 },
                new Product { ProductId = 3, ProductName = "Ürün3", Price = 300 }


                );
        }
    }
}
