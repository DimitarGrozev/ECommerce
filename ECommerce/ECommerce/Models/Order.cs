using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } 

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}
