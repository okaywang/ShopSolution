using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SE.Website.Models
{
    public class CommunityListItemModel : ITranslatable<Community, CommunityListItemModel>, ITranslatable<CommunityListItemModel, Community>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string CountyName { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public int ProvinvceId { get; set; }
        public int CityId { get; set; }
        public int CountyId { get; set; }


        public CommunityListItemModel Translate(Community from)
        {
            this.Id = from.Id;
            this.Name = from.Name;
            this.Longitude = from.Longitude;
            this.Latitude = from.Latitude;
            if (from.ChinaCounty != null)
            {
                this.CountyName = from.ChinaCounty.Name;
                this.CityName = from.ChinaCounty.ChinaCity.Name;
                this.ProvinceName = from.ChinaCounty.ChinaCity.ChinaProvince.Name;

                this.CountyId = from.CountyId;
                this.CityId = from.ChinaCounty.CityId;
                this.ProvinvceId = from.ChinaCounty.ChinaCity.ChinaProvince.Id;
            }
            return this;
        }

        public Community Translate(CommunityListItemModel from)
        {
            var bll = DependencyResolver.Current.GetService<SE.BussinessLogic.CommunityBussinessLogic>();
            var to = from.Id > 0 ? bll.Get(from.Id) : new Community();
            to.CountyId = from.CountyId;
            to.Name = from.Name;
            to.Longitude = from.Longitude;
            to.Latitude = from.Latitude;
            return to;
        }
    }


}