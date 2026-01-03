using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.EFramework;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace MuhsinYigitÖrücü.Controllers
{

    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;

        public LoginController()
        {
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation(), new CheckAdminForLoginValidation());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            try
            {
                var getadmin = _adminService.TCheckAdminForLogin(a.MailAddress, a.Password);

                if (getadmin.Count != 0)
                {
                    if (getadmin[0].Status)
                    {
                        FormsAuthentication.SetAuthCookie(getadmin[0].MailAddress, false);
                        Session["NameSurname"] = getadmin[0].NameSurname;
                        Session["Image"] = getadmin[0].Image;
                        Session["RoleName"] = getadmin[0].Role.RoleType;
                        return RedirectToAction("Admin", "Admin");
                    }
                    else
                    {
                        throw new ValidationException("Bu kullanıcı pasif durumdadır.Lütfen Yönetici ile iletişime geçiniz");
                    }
                }
                else
                {
                    throw new ValidationException("Mail adresi veya Şifre Hatalıdır.Lütfen tekrar deneyiniz!!!");
                }

            }
            catch (ValidationException ex)
            {
                if (ex.Errors.Any())
                {
                    foreach (var item in ex.Errors)
                    {
                        ModelState.AddModelError("", item.ErrorMessage);
                    }

                    TempData["ErrorMessage"] = string.Join(",", ex.Errors.Select(x => x.ErrorMessage));
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                    TempData["ErrorMessage"] = ex.Message;
                }

                TempData["RedirectToAction"] = "/Users/HomePage";
                return RedirectToAction("ErrorPageForAdminLoginInHomePage", "ErrorPages");
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Users");
        }
    }
}