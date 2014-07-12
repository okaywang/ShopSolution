
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
    public class CustomerController : Controller
    {
        private CustomerBussinessLogic _customerBll;
        private OrderBussinessLogic _orderBll;
        public CustomerController(CustomerBussinessLogic customerBll,OrderBussinessLogic orderBll)
        {
            _customerBll = customerBll;
            _orderBll = orderBll;
        }
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult List(CustomerSearchCriteria criteria)
        {
            var result = _customerBll.Search(criteria);
            var model = result.ToPagedModel<Customer, CustomerModel>();
            return PartialView("_List", model);
        }
      


    }
}
