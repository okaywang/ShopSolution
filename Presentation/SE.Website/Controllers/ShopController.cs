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
    public class ShopController : Controller
    {
        private ShopBussinessLogic _shopBll;
        public ShopController(ShopBussinessLogic shopBll)
        {
            _shopBll = shopBll;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult List(ShopSearchCriteria criteria)
        {
            criteria.IsIntegral = true;
            var shops = _shopBll.Search(criteria);
            var model = shops.ToPagedModel<Shop, ShopListItemModel>();
            return PartialView("_List", model);
        }

        /// <summary>
        /// 商户编辑
        /// </summary>
        public ActionResult Edit(int id)
        {
            var shop = _shopBll.Get(id);
            Guard.IsNotNull<DataNotFoundException>(shop);
            var model = new EditShopModel().Translate(shop);
            return View(model);
        }

        /// <summary>
        /// 更新商户信息
        /// </summary>
        public JsonResult Update(EditShopModel model)
        {
            var entity = model.Translate();
            if (!entity.IsIntegral)
            {
                entity.IsIntegral = true;
                entity.ShopOpenDateTime = DateTime.Now;
                entity.CooperationStatus = Common.Types.ShopCooperationStatus.OpenShop;
            }
            _shopBll.Update(entity);
            return Json(new ResultModel(true));
        }

        /// <summary>
        /// 商户详情
        /// </summary>
        public ActionResult Detail(int id)
        {
            var shop = _shopBll.Get(id);
            Guard.IsNotNull<DataNotFoundException>(shop);
            var model = new ShopDetailModel().Translate(shop);
            return View(model);
        }

        /// <summary>
        /// 关店
        /// </summary>
        public JsonResult CloseShop(int shopId)
        {
            var shop = _shopBll.Get(shopId);
            Guard.IsNotNull<DataNotFoundException>(shop);
            shop.CooperationStatus = Common.Types.ShopCooperationStatus.CloseShop;
            _shopBll.Update(shop);
            return Json(new ResultModel(true));
        }

        /// <summary>
        /// 打烊
        /// </summary>
        /// <returns></returns>
        public JsonResult StopBussinessing(int shopId, DateTime TemporaryClosingBeginDate, DateTime TemporaryClosingEndDate)
        {
            var shop = _shopBll.Get(shopId);
            Guard.IsNotNull<DataNotFoundException>(shop);
            shop.TemporaryClosingBeginDate = TemporaryClosingBeginDate;
            shop.TemporaryClosingEndDate = TemporaryClosingEndDate;
            _shopBll.Update(shop);
            return Json(new ResultModel(true)); 
        }
    }
}