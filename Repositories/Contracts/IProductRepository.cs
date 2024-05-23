using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoriesBase<Product>
    {
        Task<PagedList<Product>> GetAllProductAsync(ProductParameters productParameters, bool trackChanges);
        Task<Product> GetOneProductByIdAsync(int id, bool trackChanges);
        void CreateOneOneProduct(Product product);
        void UpdateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        Task<List<Product>> GetAllProductAsync(bool trackChanges);
    }
}
