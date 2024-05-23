using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ProductDto;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IProductLinks _productLinks;

        public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IProductLinks productLinks)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _productLinks = productLinks;
        }

        public async Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.CreateOneOneProduct(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(entity); ;
        }

        public async Task DeleteOneProductAsync(int id, bool trackChanhes)
        {
            var entity = await GetOneProductByIdAndCheckExists(id, trackChanhes);

            _manager.Product.DeleteOneProduct(entity);
            await _manager.SaveAsync();
        }

       

        public async Task<(LinkResponse linkResponse, MetaData metaData)> 
            GetAllProductAsync(LinkParameters linkParameters, bool trackChanhes)
        {
            if(!linkParameters.ProductParameters.ValidPriceRange)
                throw new PriceOutofRangeBadRequestException();
            var productsWithMetaData = await _manager
                .Product
                .GetAllProductAsync(linkParameters.ProductParameters, trackChanhes);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);

            var links = _productLinks.TryGenerateLinks(productDto,
               linkParameters.ProductParameters.Fields,
               linkParameters.HttpContext);

            return (linkResponse: links, metaData: productsWithMetaData.MetaData);
        }

        public async Task<List<Product>> GetAllProductAsync(bool trackChanhes)
        {
            var product = await _manager.Product.GetAllProductAsync(trackChanhes);
            return product;
        }

        public async Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanhes)
        {
            var product = await GetOneProductByIdAndCheckExists(id, trackChanhes);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<(ProductDtoForUpdate productDtoForUpdate, Product product)> GetOneProductForPatchAsync(int id, bool trackChanges)
        {
            var product = await GetOneProductByIdAndCheckExists(id, trackChanges);

            var productDtoForUpdate = _mapper.Map<ProductDtoForUpdate>(product);
            return (productDtoForUpdate, product);
        }

        public async Task SaveProductForPatchAsync(ProductDtoForUpdate productDtoForUpdate, Product product)
        {
            _mapper.Map(productDtoForUpdate, product);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges)
        {
            var entity = await GetOneProductByIdAndCheckExists(id, trackChanges);



            //mapping
            entity = _mapper.Map<Product>(productDto);
            _manager.Product.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Product> GetOneProductByIdAndCheckExists(int id, bool trackChanhes)
        {
            // check entity 
            var entity = await _manager.Product.GetOneProductByIdAsync(id, trackChanhes);

            if (entity is null)
                throw new CampaingNotFoundException(id);

            return entity;
        }
    }
}
