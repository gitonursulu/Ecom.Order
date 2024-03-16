using Order.Domain.Entities;
using Order.Domain.Interfaces;
using Order.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Models
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid Id { get; set; }
        public Guid Owner { get; set; }
        public virtual List<OrderItem> Items { get; set; }
        public OrderAddress OrderAddress { get; set; }
    }
}
