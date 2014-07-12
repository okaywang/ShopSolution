using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.Website.Models
{
    public class ShopAccountModel : ITranslatable<Shop, ShopAccountModel>
    {
        public int ShopId { get; set; }
        public int AccountId { get; set; }
        public string LoginName { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public ShopAccountModel Translate(Shop from)
        {
            var to = new ShopAccountModel();
            to.ShopId = from.Id;
            to.AccountId = from.Account.Id;
            to.Name = from.Name;
            to.LoginName = from.Account.LoginName;
            to.CityName = from.ChinaCounty.ChinaCity.Name;
            return to;
        }
    }

    public interface ITranslatable<TFrom, TTo>
    {
        TTo Translate(TFrom from);
    }
     
    public interface ITranslatableTo<TTo>
    {
        TTo Translate();
    }
}