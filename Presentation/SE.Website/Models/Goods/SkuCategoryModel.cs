using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.Website.Models
{
    public class SkuCategoryItemModel : ITranslatable<SkuCategory, SkuCategoryItemModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeCount { get; set; }

        public SkuCategoryItemModel Translate(SkuCategory from)
        {
            this.Id = from.Id;
            this.Name = from.Name;
            if (from.SkuType!=null)
            {
                this.TypeCount = from.SkuType.Count();
            }
            return this;
        }
    }
}