﻿using System.Collections;

namespace ECommerce.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return OrderDetails?.Sum(x => x.ProductPrice * x.Quantity) ?? 0;
            }
        }
        public DateTime OrderDate { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
