using SE.BussinessLogic;
using SE.DataAccess;
using SE.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SE.Website.Controllers
{
    public class GoodsController : Controller
    {
        private GoodsBussinessLogic _goodsBll;
        public GoodsController(GoodsBussinessLogic goodsBll)
        {
            _goodsBll = goodsBll;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Add()
        {
            return View("Edit");
        }
        public ActionResult Edit()
        {
            return View("Edit");
        }
        //商品分类
        public ActionResult Category()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Category(SkuCategorySearchCriteria criteria)
        {
            var result = _goodsBll.GetSkuCategory(criteria);
            var model = result.ToPagedModel<SkuCategory, SkuCategoryItemModel>();
            return PartialView("_Category", model);
        }
        //商品类型
        public ActionResult Type(int? cid)
        {
            var categoryList = _goodsBll.GetSkuCategory(new SkuCategorySearchCriteria());
            SkuTypeModel model = new SkuTypeModel()
            {
                SkuCategoryItem = categoryList.ToPagedModel<SkuCategory, SkuCategoryItemModel>().Items,
                CategoryId=cid.HasValue?cid.Value:0
            };
            return View(model);
        }
        [HttpPost]
        public PartialViewResult Type(SkuTypeSearchCriteria criteria)
        {
            var result = _goodsBll.GetSkuType(criteria);
            var model = result.ToPagedModel<SkuType, SkuTypeItemModel>();
            return PartialView("_Type", model);
        }

    }
}
