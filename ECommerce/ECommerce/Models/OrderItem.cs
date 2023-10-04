﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ECommerce.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        public Guid OrderId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ItemPrice { get; set; }
    }
}
