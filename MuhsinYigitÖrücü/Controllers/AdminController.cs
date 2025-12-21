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
        private readonly IAboutService _aboutService;
        private readonly IEducationService _educationService;

        public AdminController()
        {
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation());
            _aboutService = new AboutManager(new EFAboutDal(), new AboutValidations());
            _educationService = new EducationManager(new EFEducationDal(), new EducationValidation());
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
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Admin", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }
        #endregion

        #region EditandUpdate
        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            #region GetRoleTypeForDropdownList
            var getRoleType = context.Roles.Select(x => new SelectListItem
            {
                Value = x.RoleID.ToString(),
                Text = x.RoleType
            });
            ViewBag.RoleType = getRoleType;
            #endregion
            var values = _adminService.TGetByID(id);
            return View("AdminEdit", values);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin a)
        {
            try
            {
                var updatedvalues = _adminService.TGetByID(a.AdminID);
                updatedvalues.NameSurname = a.NameSurname;
                updatedvalues.Password = a.Password;
                updatedvalues.Status = a.Status;
                updatedvalues.RoleID = a.RoleID;
                _adminService.TUpdate(updatedvalues);
                return RedirectToAction("Admin");
            }
            catch (ValidationException ex)
            {
                var errorMessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errorMessage;
                TempData["RedirectUrl"] = Url.Action("Admin","Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }
        #endregion

        #endregion

        #region AboutOperation

        #region GetList
        public ActionResult About()
        {
            var values = _aboutService.TGetAllList();
            return View(values);
        }
        #endregion

        #region Add
        [HttpPost]
        public ActionResult AboutAdd(About a)
        {
            try
            {
                _aboutService.TInsert(a);
                return RedirectToAction("About");
            }
            catch (ValidationException ex)
            {
                var errorMessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errorMessage;
                TempData["RedirectUrl"] = Url.Action("About","Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }
        #endregion

        #region EditAndUpdate
        [HttpGet]
        public ActionResult AboutEdit(int id)
        {
            var values = _aboutService.TGetByID(id);
            return View("AboutEdit", values);
        }
        [HttpPost]
        public ActionResult AboutUpdate(About a)
        {
            try
            {
                var updatedvalue = _aboutService.TGetByID(a.AboutID);
                updatedvalue.NameSurname = a.NameSurname;
                updatedvalue.Job = a.Job;
                updatedvalue.ShortDescription = a.ShortDescription;
                updatedvalue.LongDescription = a.LongDescription;
                updatedvalue.Image = a.Image;
                updatedvalue.Status = a.Status;

                _aboutService.TUpdate(updatedvalue);
                return RedirectToAction("About");
            }
            catch (ValidationException ex)
            {
                var errorMessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errorMessage;
                TempData["RedirectUrl"] = Url.Action("About", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
                throw;
            }
        }
        #endregion

        #endregion

        #region EducationOperations

        #region GetList
        public ActionResult Education()
        {
            var values = _educationService.TGetAllList();
            return View(values);
        }
        #endregion

        #endregion
    }
}