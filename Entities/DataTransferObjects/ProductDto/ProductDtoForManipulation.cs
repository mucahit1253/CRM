using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ProductDto
{
    public abstract record ProductDtoForManipulation
    {
        [Required(ErrorMessage = "Title is a required field.")]
        [MinLength(2, ErrorMessage = "Title must consist of at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Title must consist of at maximum 50 characters")]
        public String ProductName { get; init; }

        [Required(ErrorMessage = "Price is a required field.")]
        public decimal Price { get; init; }

        
    }
}
