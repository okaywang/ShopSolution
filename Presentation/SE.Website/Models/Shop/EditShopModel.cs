using SE.BussinessLogic;
using SE.Common.Types;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SE.Website.Models
{
    public class EditShopModel : ITranslatable<Shop, EditShopModel>, ITranslatableTo<Shop>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LoginName { get; set; }

        public int ProvinceId { get; set; }

        public int CityId { get; set; }

        public int CountyId { get; set; }

        [Required]
        public string DetailAddress { get; set; }

        public string ContactName { get; set; }

        public GenderType? ContactGender { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string TelePhoneNumber { get; set; }

        public TimeSpan? OpeningTime { get; set; }

        public TimeSpan? ClosingTime { get; set; }

        public int? DeliveryMinAmount { get; set; }

        public int? DeliveryRate { get; set; }

        public EditShopModel Translate(Shop from)
        {
            this.Id = from.Id;
            this.Name = from.Name;
            this.LoginName = from.Account.LoginName;
            this.DetailAddress = from.DetailAddress;
            this.ContactName = from.ContactName;
            this.ContactGender = from.ContactGender;
            this.MobilePhoneNumber = from.MobilePhoneNumber;
            this.TelePhoneNumber = from.TelePhoneNumber;
            this.DeliveryMinAmount = from.DeliveryMinAmount;
            this.DeliveryRate = from.DeliveryRate;
            this.OpeningTime = from.DailyOpeningTime;
            this.ClosingTime = from.DailyClosingTime;
            this.CountyId = from.CountyId;
            if (from.ChinaCounty != null)
            {
                this.CityId = from.ChinaCounty.CityId;
                this.ProvinceId = from.ChinaCounty.ChinaCity.ProvinceId;
            }
            return this;
        }

        public Shop Translate()
        {
            var bll = DependencyResolver.Current.GetService<ShopBussinessLogic>();
            var to = this.Id > 0 ? bll.Get(this.Id) : new Shop();
            to.DetailAddress = this.DetailAddress;
            to.ContactName = this.ContactName;
            to.ContactGender = this.ContactGender;
            to.MobilePhoneNumber = this.MobilePhoneNumber;
            to.TelePhoneNumber = this.TelePhoneNumber;
            to.DeliveryMinAmount = this.DeliveryMinAmount;
            to.DeliveryRate = this.DeliveryRate;
            to.DailyOpeningTime = this.OpeningTime;
            to.DailyClosingTime = this.ClosingTime;
            to.CountyId = this.CountyId;
            return to;
        }
    }
}