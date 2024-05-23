using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ProductDto;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(LinkResponse linkResponse, MetaData metaData)> GetAllProductAsync(LinkParameters linkParameters, bool trackChanhes);
        Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanhes);
        Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion product);
        Task UpdateOneProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges);
        Task DeleteOneProductAsync(int id, bool trackChanhes);
        Task<(ProductDtoForUpdate productDtoForUpdate, Product product)> GetOneProductForPatchAsync(int id, bool trackChanges);

        Task SaveProductForPatchAsync(ProductDtoForUpdate productDtoForUpdate, Product product);
        Task<List<Product>> GetAllProductAsync(bool trackChanhes);

    }
}
