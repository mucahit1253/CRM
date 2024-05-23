using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ProductDto;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/Products")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        [Authorize]
        [HttpHead]
        [HttpGet(Name = "GetAllProductAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]

        public async Task<IActionResult> GetAllProductsAsync([FromQuery] ProductParameters productParameters)
        {
            var linkParameters = new LinkParameters()
            {
                ProductParameters = productParameters,
                HttpContext = HttpContext
            };


            var result = await _manager.
                ProductService.
                GetAllProductAsync(linkParameters, false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

            return result.linkResponse.HasLinks ?
                Ok(result.linkResponse.LinkedEntities) :
                Ok(result.linkResponse.ShapedEntities);


        }
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProductAsync([FromRoute(Name = "id")] int id)
        {
            var product = await _manager.ProductService.GetOneProductByIdAsync(id, false);


            return Ok(product);



        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Editor,Admin,Personel")]
        [HttpPost(Name = "CreateOneProductAsync")]
        public async Task<IActionResult> CreateOneProductAsync([FromBody] ProductDtoForInsertion productDto)
        {



            var product = await _manager.ProductService.CreateOneProductAsync(productDto);

            return StatusCode(201, product);





        }
        [Authorize(Roles = "Editor,Admin,Personel")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneProductAsync([FromRoute(Name = "id")] int id,
            [FromBody] ProductDtoForUpdate productDto)
        {


            await _manager.ProductService.UpdateOneProductAsync(id, productDto, false);

            return NoContent();


        }
        [Authorize(Roles = "Editor,Admin,Personel")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneProductAsync([FromRoute(Name = "id")] int id)
        {

            await _manager.ProductService.DeleteOneProductAsync(id, false);

            return NoContent();
        }
        [Authorize(Roles = "Editor,Admin,Personel")]
        [HttpOptions]
        public IActionResult GetProductOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
   
}
