using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.Website.Models
{
    public class OrderModel : ITranslatable<OrderHead, OrderModel>
    {
        public string OrderNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string ShopMsg { get; set; }
        public string Remarks { get; set; }
        public OrderDetailModel[] Details { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderModel Translate(OrderHead from)
        {
            this.OrderNumber = from.OrderNumber;
            this.TransactionDateTime = from.TransactionDateTime;
            this.Remarks = from.Remarks;
            this.ShopMsg = GetShopMsg(from);
            this.Details = new OrderDetailModel[from.OrderBody.Count];
            var i = 0;
            foreach (var item in from.OrderBody)
            {
                this.Details[i] = new OrderDetailModel().Translate(item);
                this.TotalPrice += item.Price * item.Quantity;
                i++;
            }
            return this;

        }

        private string GetShopMsg(OrderHead from)
        {
            var city = from.Shop.ChinaCounty.ChinaCity.Name;
            var county = from.Shop.ChinaCounty.Name;
            var telePhoneNumber = from.Shop.TelePhoneNumber == null ? "无" : from.Shop.TelePhoneNumber;
            var mobilePhoneNumber = from.Shop.MobilePhoneNumber== null ? "无" : from.Shop.MobilePhoneNumber;
            var detailAddress = from.Shop.DetailAddress;
            var shopMsg = string.Format("{0} 地址:{1}{2}{3}.座机:{4} 手机:{5}", from.Shop.Name, city, county, detailAddress, telePhoneNumber, mobilePhoneNumber);
            return shopMsg.ToString();
        }
    }
}