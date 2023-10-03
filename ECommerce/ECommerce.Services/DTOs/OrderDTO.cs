using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.DTOs
{
    public class OrderDTO
    {
        public int CustomerId { get; set; }

        public List<OrderItemDTO> OrderItems { get; set;}
    }
}
