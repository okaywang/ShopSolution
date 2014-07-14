using SE.BussinessLogic;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SE.Website.Models
{
    public class BrandModel : ITranslatable<Brand, BrandModel>, ITranslatable<BrandModel, Brand>
    {
        public BrandModel()
        {
            SkuTypes = new List<string>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> SkuTypes { get; set; }

        public BrandModel Translate(Brand from)
        {
            this.Id = from.Id;
            this.Name = from.Name;
            this.SkuTypes = from.BrandSkuType.Select(i => i.SkuType.Name).ToList();
            return this;
        }

        public Brand Translate(BrandModel from)
        {
            var bll = DependencyResolver.Current.GetService<BrandBussinessLogic>();
            var to = from.Id > 0 ? bll.Get(from.Id) : new Brand();
            to.Name = from.Name;
            return to;
        }
    }
}