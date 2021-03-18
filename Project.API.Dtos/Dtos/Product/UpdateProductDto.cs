using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Dtos.Dtos.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
