using Entities.DataTransferObjects.ProductDto;
using Entities.LinkModels;
using System.Net.Http;
using Microsoft.AspNetCore.Http;


namespace Services.Contracts
{
    public interface IProductLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<ProductDto> productDto,
            string fields, HttpContext httpContext);
    }
}
