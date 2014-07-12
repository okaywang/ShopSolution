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
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private OrderBussinessLogic _orderBll;
        public OrderController(OrderBussinessLogic orderBll)
        {
            _orderBll = orderBll;
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 用户订单详情
        /// </summary>
        /// <returns></returns>
        /// 
      
        [HttpGet]
        public ActionResult CustomerOrders()
        { 
            return View();
        }

        [HttpPost]
        public PartialViewResult CustomerOrders(OrderSearchCriteria criteria)
        { 
            var orderHeads = _orderBll.Search(criteria);
            var model = orderHeads.ToPagedModel<OrderHead, OrderModel>();
            return PartialView("_CustomerOrders", model);
        }
    }
}
