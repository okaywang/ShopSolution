
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
    public class AccountController : Controller
    {
        private ShopBussinessLogic _shopBll;
        private AccountBussinessLogic _accountBll;
        private PersonBussinessLogic _personBll;
        public AccountController(ShopBussinessLogic shopBll, AccountBussinessLogic accountBll, PersonBussinessLogic personBll)
        {
            _shopBll = shopBll;
            _accountBll = accountBll;
            _personBll = personBll;
        }

        public ActionResult Index()
        {
            return View();
        }
        #region 登录

        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(AccountModel model)
        {
            return Json(new ResultModel(true));

            var reModel = model.CheckModel();
            if (!reModel.IsSuccess)
            {
                return Json(reModel);
            }
            var captcha = Session["captcha"];
            if (captcha == null || !captcha.ToString().Equals(model.Captcha, StringComparison.CurrentCultureIgnoreCase))
            {
                return Json(new ResultModel(false, "验证码错误"));
            }
            var entity = _accountBll.GetAccountByLoginName(model.LoginName);
            if (entity == null)
            {
                return Json(new ResultModel(false, "用户名或密码错误"));
            }
            if (!entity.Password.Equals(model.Password))
            {
                return Json(new ResultModel(false, "密码错误"));
            }
            IAuthenticationService _authenticationService = new FormAuthenticationService();
            _authenticationService.SignIn(model.LoginName, model.RememberMe);

            return Json(new ResultModel(true));
        }
        //验证码生成
        public FileContentResult CaptchaImage()
        {
            var captcha = new LiteralCaptcha(60, 30, 4);
            var bytes = captcha.Generate();
            Session["captcha"] = captcha.Captcha;
            return new FileContentResult(bytes, "image/jpeg"); ;
        }

        public ActionResult Logout()
        {
            IAuthenticationService _authenticationService = new FormAuthenticationService();
            _authenticationService.SignOut();
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region 删除账号
        public JsonResult Delete(int accountId)
        {
            var account = _accountBll.Get(accountId);
            Guard.IsNotNull<DataNotFoundException>(account);
            _accountBll.Delete(account);
            return Json(new ResultModel(true));
        }
        #endregion

        #region 重设密码
        [HttpPost]
        public ActionResult ResetPassword(int accountId)
        {
            var account = _accountBll.Get(accountId);
            Guard.IsNotNull<DataNotFoundException>(account);
            account.Password = "123456";
            _accountBll.Update(account);
            return Json(new ResultModel(true));
        }
        #endregion

        #region 账号密码修改
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            var account = _accountBll.Get(model.AccountId);
            Guard.IsNotNull<DataNotFoundException>(account);
            if (account.Password != model.OldPassword)
            {
                return Json(new ResultModel(false, "原密码不正确"));
            }
            account.Password = model.NewPassword;
            _accountBll.Update(account);
            return Json(new ResultModel(true));
        }
        #endregion

        #region 商户账号
        public ActionResult Shops()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Shops(ShopSearchCriteria criteria)
        {
            var result = _shopBll.Search(criteria);
            var model = result.ToPagedModel<Shop, ShopAccountModel>();
            return PartialView("_Shops", model);
        }
        #endregion

        #region 内部账号
        public ActionResult Persons()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Persons(PersonSearchCriteria criteria)
        {
            var result = _personBll.Search(criteria);
            var model = result.ToPagedModel<AdminPerson, PersonAccountModel>();
            return PartialView("_Persons", model);
        }

        public JsonResult AddPersonAccount(PersonAccountModel model)
        {
            var entity = model.Translate(model);
            _personBll.Insert(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult UpdatePersonAccount(PersonAccountModel model)
        {
            var entity = model.Translate(model);
            _personBll.Update(entity);
            return Json(new ResultModel(true));
        }
        #endregion

    }
}
