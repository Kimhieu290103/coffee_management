using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeManagement.Models.Model
{
    public class Order_detail
    {
        private int orderId { get; set; }
        private int productId { get; set; }
        private int quantity { get; set; }

        public Order_detail(int orderId, int productId, int quantity)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.quantity = quantity;
        }
    }
}