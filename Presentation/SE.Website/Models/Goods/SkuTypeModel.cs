using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.Website.Models
{

    public class SkuTypeModel
    {
        public int CategoryId { get; set; }
        public IList<SkuCategoryItemModel> SkuCategoryItem { get; set; }
    }

    public class SkuTypeItemModel : ITranslatable<SkuType, SkuTypeItemModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoodsCount { get; set; }

        public SkuTypeItemModel Translate(SkuType from)
        {
            this.Id = from.Id;
            this.Name = from.Name;
            return this;
        }
    }
}