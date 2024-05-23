using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ProductDto
{
    public class ProductDto
    {

        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
