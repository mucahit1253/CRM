using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ProductDto
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        [Required]
        public int ProductId { get; set; }
    }
}
