using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ProductDto;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductLinks : IProductLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<ProductDto> _dataShaper;

        public ProductLinks(LinkGenerator linkGenerator,
            IDataShaper<ProductDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public LinkResponse TryGenerateLinks(IEnumerable<ProductDto> productDto, string fields, HttpContext httpContext)
        {
            var shapedProduct = ShapeData(productDto, fields);
            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkedProduct(productDto, fields, httpContext, shapedProduct);
            return ReturnShapedProducts(shapedProduct);
        }

        private LinkResponse ReturnLinkedProduct(IEnumerable<ProductDto> productDto,
           string fields,
           HttpContext httpContext,
           List<Entity> shapedProduct)
        {
            var productDtoList = productDto.ToList();

            for (int index = 0; index < productDtoList.Count(); index++)
            {
                var productLinks = CreateForproduct(httpContext, productDtoList[index], fields);
                shapedProduct[index].Add("Links", productLinks);
            }

            var productCollection = new LinkCollectionWrapper<Entity>(shapedProduct);
            CreateForProducts(httpContext, productCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = productCollection };
        }

        private LinkCollectionWrapper<Entity> CreateForProducts(HttpContext httpContext,
           LinkCollectionWrapper<Entity> productCollectionWrapper)
        {
            productCollectionWrapper.Links.Add(new Link()
            {
                Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                Rel = "self",
                Method = "GET"
            });
            return productCollectionWrapper;
        }
        private List<Link> CreateForproduct(HttpContext httpContext,
            ProductDto productDto,
            string fields)
        {
            var links = new List<Link>()
            {
               new Link()
               {
                   Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}" +
                   $"/{productDto.ProductId}",
                   Rel = "self",
                   Method = "GET"
               },
               new Link()
               {
                   Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                   Rel="create",
                   Method = "POST"
               },
            };
            return links;
        }

        private LinkResponse ReturnShapedProducts(List<Entity> shapedProduct)
        {
            return new LinkResponse() { ShapedEntities = shapedProduct };
        }

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            ///klj
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType
                .SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private List<Entity> ShapeData(IEnumerable<ProductDto> productsDto, string fields)
        {
            return _dataShaper
                .ShapeData(productsDto, fields)
                .Select(c => c.Entity)
                .ToList();
        }
    }
}
