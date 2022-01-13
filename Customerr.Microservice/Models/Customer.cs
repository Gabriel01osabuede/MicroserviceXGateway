using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customerr.Microservice.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeltedDate { get; set; }
    }
}
