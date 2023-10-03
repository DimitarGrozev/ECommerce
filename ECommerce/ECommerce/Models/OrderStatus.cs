using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public enum OrderStatus
    {
        New,
        Pending,
        Shipped,
        Delivered,
        Cancelled,
        Returned
    }
}
