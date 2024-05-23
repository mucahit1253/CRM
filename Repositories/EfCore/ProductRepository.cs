using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class ProductRepository : RepositoriesBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneOneProduct(Product product) => Create(product);



        public void DeleteOneProduct(Product product)=>Delete(product);

        public async Task<List<Product>> GetAllProductAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(b => b.ProductId)
                .ToListAsync();
        }

        public async Task<PagedList<Product>> GetAllProductAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await FindAll(trackChanges)
               .FilterProducts(productParameters.MinPrice, productParameters.MaxPrice)
               .Search(productParameters.SearchTerm)
               .Sort(productParameters.OrderBy)
               .ToListAsync();
            return PagedList<Product>
                .ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
        }

        public async Task<Product> GetOneProductByIdAsync(int id, bool trackChanges)=>
        
            await FindByCondition(c => c.ProductId.Equals(id), trackChanges)
           .SingleOrDefaultAsync();

        

        public void UpdateOneProduct(Product product)=>Update(product);
       
    }
}
