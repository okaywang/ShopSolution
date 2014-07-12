using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SE.Website.Models
{
    public class ShopDetailModel : ITranslatable<Shop, ShopDetailModel>
    {
        public ShopDetailModel()
        {
            ServedCommunities = new List<string>();
        }

        public string Name { get; set; }

        public string LoginName { get; set; }

        public string DetailAddress { get; set; }

        public string ContactName { get; set; }

        public string MobilePhoneNumber { get; set; }

        public TimeSpan? OpeningTime { get; set; }

        public TimeSpan? ClosingTime { get; set; }

        public decimal? DeliveryMinAmount { get; set; }

        public decimal? DeliveryRate { get; set; }

        public string ImageFilePath { get; set; }

        public List<string> ServedCommunities { get; set; }

        public ShopDetailModel Translate(Shop from)
        {
            this.Name = from.Name;
            this.LoginName = from.Account.LoginName;
            this.DetailAddress = from.DetailAddress;
            this.ContactName = from.ContactName;
            this.MobilePhoneNumber = from.MobilePhoneNumber;
            this.OpeningTime = from.DailyOpeningTime;
            this.ClosingTime = from.DailyClosingTime;
            this.DeliveryMinAmount = from.DeliveryMinAmount;
            this.DeliveryRate = from.DeliveryRate;
            this.ImageFilePath = from.ImageFileName;
            this.ServedCommunities = from.CommunityShop.Select(i => i.Community.Name).ToList();
            return this;
        }
    }
}