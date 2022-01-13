using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Dtos
{
    public class AddProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
    public class updateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }

    public class deleteProduct
    {
        public DateTime DeletedAt { get; set; } = DateTime.Now;
    }
}
