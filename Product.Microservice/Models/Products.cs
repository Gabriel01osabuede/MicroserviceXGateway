using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Models
{
    public class Products
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; } 
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedAt { get; set; } 

    }
}
