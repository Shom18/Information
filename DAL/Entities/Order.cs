using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_backend.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Name_order { get; set; }
    }
}
