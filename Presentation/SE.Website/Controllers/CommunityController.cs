using SE.BussinessLogic;
using SE.DataAccess;
using SE.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core.Guards;
using WebExpress.Website.Exceptions;

namespace SE.Website.Controllers
{
    public class CommunityController : Controller
    {
        private CommunityBussinessLogic _communityBll;
        public CommunityController(CommunityBussinessLogic communityBll)
        {
            _communityBll = communityBll;
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult List(CommunitySearchCriteria criteria)
        {
            var result = _communityBll.Search(criteria);
            var model = result.ToPagedModel<Community, CommunityListItemModel>();
            return PartialView("_List", model);
        }

        public JsonResult Add(CommunityListItemModel model)
        {
            var entity = model.Translate(model);
            _communityBll.Insert(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult Update(CommunityListItemModel model)
        {
            var entity = model.Translate(model);
            _communityBll.Update(entity);
            return Json(new ResultModel(true));
        }

        /// <summary>
        /// 删除楼宇
        /// </summary>
        public JsonResult Delete(int id)
        {
            var entity = _communityBll.Get(id);
            Guard.IsNotNull<DataNotFoundException>(entity);
            _communityBll.Delete(entity);
            return Json(new ResultModel(true));
        }
    }
}