using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.Website.Models
{
    public class OrderDetailModel : ITranslatable<OrderBody, OrderDetailModel>
    {
        public string SkuName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public OrderDetailModel Translate(OrderBody from)
        {
            this.SkuName = from.Sku.Name;
            this.Quantity = from.Quantity;
            this.Price = from.Price;
            return this;
        }
    }

}