using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Context;
using DataAccessLayer.EFramework;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuhsinYigitÖrücü.Controllers
{
    public class AdminController : Controller
    {
        #region Construction
        MYOContext context = new MYOContext();
        private readonly IAdminService _adminService;

        public AdminController()
        {
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation());
        }
        #endregion
        #region AdminOperations

        #region GetList
        public ActionResult Admin()
        {
            #region GetRoleTypeForDropdownList
            var getRoleType = context.Roles.Select(x => new SelectListItem
            {
                Value = x.RoleID.ToString(),
                Text = x.RoleType
            });
            ViewBag.RoleType = getRoleType;
            #endregion

            var values = _adminService.TGetAllList();
            return View(values);
        }
        #endregion

        #region Add
        [HttpPost]
        public ActionResult AdminAdd(Admin a)
        {
            try
            {
                _adminService.TInsert(a);
                return RedirectToAction("Admin");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["AdminError"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Admin", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }
        #endregion

        #endregion
    }
}