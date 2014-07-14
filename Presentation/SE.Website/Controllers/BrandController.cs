using SE.BussinessLogic;
using SE.DataAccess;
using SE.Website.Filters;
using SE.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;
using WebExpress.Core.Guards;
using WebExpress.Website.Exceptions;

namespace SE.Website.Controllers
{
    public class BrandController : Controller
    {
        private BrandBussinessLogic _brandBll;
        public BrandController(BrandBussinessLogic brandBll)
        {
            _brandBll = brandBll;
        }

        public JsonResult Delete(int id)
        {
            var brand = _brandBll.Get(id);
            Guard.IsNotNull<DataNotFoundException>(brand);
            _brandBll.Delete(brand);
            return Json(new ResultModel(true));
        }

        public JsonResult Add(string name)
        {
            var entity = new Brand() { Name = name };
            _brandBll.Insert(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult Update(BrandModel model)
        {
            var entity = model.Translate(model);
            _brandBll.Update(entity);
            return Json(new ResultModel(true));
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult List(BrandSearchCriteria criteria)
        {
            var result = _brandBll.Search(criteria);
            var model = result.ToPagedModel<Brand, BrandModel>();
            return PartialView("_List", model);
        }
    }
}