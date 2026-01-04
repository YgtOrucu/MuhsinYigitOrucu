using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Context;
using DataAccessLayer.EFramework;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IExperienceService _experienceService;
        private readonly IRoleService _roleService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly ISkillsService _skillsService;
        private readonly IPortfolyoService _portfolyoService;
        private readonly IPortfolyoImagesService _portfolyoImagesService;
        private readonly IContactService _contactService;

        public AdminController()
        {
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation(), new CheckAdminForLoginValidation());
            _aboutService = new AboutManager(new EFAboutDal(), new AboutValidations());
            _educationService = new EducationManager(new EFEducationDal(), new EducationValidation());
            _experienceService = new ExperienceManager(new EFExperienceDal(), new ExperienceValidation());
            _roleService = new RoleManager(new EFRoleDal());
            _socialMediaService = new SocialMediaManager(new EFSocialMediaDal());
            _skillsService = new SkillsManager(new EFSkillsDal(), new SkillsValidation());
            _portfolyoService = new PortfolyoManager(new EFPortfolyoDal(), new PortfolyoValidation());
            _portfolyoImagesService = new PortfolyoImagesManager(new EFPortfolyoImagesDal());
            _contactService = new ContactManager(new EFContactDal());
        }
        #endregion

        #region AdminOperations

        #region GetList
        public ActionResult Admin()
        {
            if (!User.IsInRole("1"))
            {
                TempData["Error"] = "Bu sayfayı görüntüleme yetkisine sahip değilsiniz";
                return RedirectToAction("ErrorPageForRolePermission", "ErrorPages");
            }

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
                updatedvalues.About = a.About;
                updatedvalues.Address = a.Address;
                updatedvalues.Phone = a.Phone;
                updatedvalues.Image = a.Image;
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
                TempData["RedirectUrl"] = Url.Action("Admin", "Admin");
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
                TempData["RedirectUrl"] = Url.Action("About", "Admin");
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

        #region Add
        [HttpPost]
        public ActionResult EducationAdd(Education e)
        {
            try
            {
                _educationService.TInsert(e);
                return RedirectToAction("Education");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Education", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");

            }
        }
        #endregion

        #region EditAndUpdate

        public ActionResult EducationEdit(int id)
        {
            var values = _educationService.TGetByID(id);
            return View("EducationEdit", values);
        }
        [HttpPost]
        public ActionResult EducationUpdate(Education e)
        {
            try
            {
                var updatedvalues = _educationService.TGetByID(e.EducationID);

                updatedvalues.HeadingName = e.HeadingName;
                updatedvalues.SubHeadingName = e.SubHeadingName;
                updatedvalues.SubHeadingName1 = e.SubHeadingName1;
                updatedvalues.Date = e.Date;
                updatedvalues.Status = e.Status;
                _educationService.TUpdate(updatedvalues);
                return RedirectToAction("Education");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Education", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }

        }
        #endregion

        #endregion

        #region ExperienceOperations

        #region GetList
        public ActionResult Experience()
        {
            var values = _experienceService.TGetAllList();
            return View(values);
        }
        #endregion

        #region Add
        [HttpPost]
        public ActionResult ExperienceAdd(Experience e)
        {
            try
            {
                _experienceService.TInsert(e);
                return RedirectToAction("Experience");

            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Experience", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }
        #endregion

        #region EditAndUpdate
        public ActionResult ExperienceEdit(int id)
        {
            var values = _experienceService.TGetByID(id);
            return View("ExperienceEdit", values);
        }
        [HttpPost]
        public ActionResult ExperienceUpdate(Experience e)
        {
            try
            {
                var updatedvalue = _experienceService.TGetByID(e.ExperienceID);

                updatedvalue.CompanyName = e.CompanyName;
                updatedvalue.JobName = e.JobName;
                updatedvalue.Place = e.Place;
                updatedvalue.Description = e.Description;
                updatedvalue.Technologies = e.Technologies;
                updatedvalue.Date = e.Date;
                updatedvalue.Status = e.Status;
                _experienceService.TUpdate(updatedvalue);
                return RedirectToAction("Experience");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Experience", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }
        #endregion

        #endregion

        #region RoleOperations

        #region GetList

        public ActionResult Role()
        {
            #region GetRoleForDropdown
            var RoleType = context.Roles.Select(x => new SelectListItem
            {
                Value = x.RoleID.ToString(),
                Text = x.RoleType
            }).ToList();
            ViewBag.getroletype = RoleType;
            #endregion

            var values = _roleService.TGetMembersImageByRole();
            return View(values);
        }

        #endregion

        #region EditAndUpdate
        [HttpGet]
        public ActionResult RoleEdit(int id)
        {
            if (!User.IsInRole("1"))
            {
                TempData["Error"] = "Bu sayfayı görüntüleme yetkisine sahip değilsiniz";
                return RedirectToAction("ErrorPageForRolePermission", "ErrorPages");
            }
            var values = _roleService.TGetByID(id);
            return View("RoleEdit", values);
        }
        [HttpPost]
        public ActionResult RoleUpdate(Role r)
        {
            var updatedrole = _roleService.TGetByID(r.RoleID);
            updatedrole.RoleType = r.RoleType;
            _roleService.TUpdate(updatedrole);
            return RedirectToAction("Role");
        }
        #endregion

        public ActionResult GetAdminByRoleType(int id)
        {
            if (!User.IsInRole("1"))
            {
                if (id == 2)
                {
                    var getmemberss = _adminService.TGetAdminByRoleID(id);
                    return View(getmemberss);
                }
                else
                {
                    TempData["Error"] = "Bu sayfayı görüntüleme yetkisine sahip değilsiniz";
                    return RedirectToAction("ErrorPageForRolePermission", "ErrorPages");
                }
            }

            var getmembers = _adminService.TGetAdminByRoleID(id);
            return View(getmembers);
        }


        #endregion

        #region SocialMediaOperations

        #region List
        public ActionResult SocialMedia()
        {
            var values = _socialMediaService.TGetAllList();
            return View(values);
        }
        #endregion

        #region Add
        public ActionResult SocialMediaAdd(SocialMedia s)
        {
            _socialMediaService.TInsert(s);
            return RedirectToAction("SocialMedia");
        }
        #endregion

        #region EditAndUpdate
        public ActionResult SocialMediaEdit(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            return View("SocialMediaEdit", values);
        }
        [HttpPost]
        public ActionResult SocialMediaUpdate(SocialMedia s)
        {
            var updatedmedia = _socialMediaService.TGetByID(s.SocialMediaID);

            updatedmedia.IconAddress = s.IconAddress;
            updatedmedia.Href = s.Href;
            updatedmedia.Status = s.Status;
            _socialMediaService.TUpdate(updatedmedia);
            return RedirectToAction("SocialMedia");
        }

        #endregion

        #endregion

        #region SkillsOperation

        #region List
        public ActionResult Skills()
        {
            var values = _skillsService.TGetAllList();
            return View(values);

        }
        #endregion

        #region Add

        public ActionResult SkillsAdd(Skills s)
        {
            try
            {
                _skillsService.TInsert(s);
                return RedirectToAction("Skills");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Skills", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");

            }
        }



        #endregion

        #region EditAndUpdate

        public ActionResult SkillsEdit(int id)
        {
            var values = _skillsService.TGetByID(id);
            return View("SkillsEdit", values);
        }
        [HttpPost]
        public ActionResult SkillsUpdate(Skills s)
        {

            try
            {
                var updatedSkills = _skillsService.TGetByID(s.SkillsID);
                updatedSkills.SkillsName = s.SkillsName;
                updatedSkills.SkillsPercentage = s.SkillsPercentage;
                updatedSkills.Status = s.Status;
                _skillsService.TUpdate(updatedSkills);
                return RedirectToAction("Skills");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Skills", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }
        #endregion

        #endregion

        #region PortfolyoOperation

        #region List

        public ActionResult Portfolyo()
        {
            var values = _portfolyoService.TGetAllList();
            return View(values);
        }
        #endregion

        #region GetImage
        public ActionResult PortfolyoImage(int id)
        {
            var values = _portfolyoService.TGetByID(id);
            return View("PortfolyoImage", values);
        }
        #endregion

        #region Add


        [HttpPost]
        public ActionResult PortfolyoAdd(Portfolyo p)
        {
            try
            {

                var uploadedFile = Request.Files["Image"];
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    var resource = Server.MapPath("~/Content/images/KısıselCV");
                    var extension = Path.GetExtension(uploadedFile.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = Path.Combine(resource, imageName);

                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(p.Image))
                    {
                        var oldImagePath = Server.MapPath(p.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    uploadedFile.SaveAs(saveLocation);
                    p.Image = "/Content/images/KısıselCV/" + imageName;
                }

                _portfolyoService.TInsert(p);
                return RedirectToAction("Portfolyo");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Portfolyo", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }


        #endregion

        #region EditAdnUpdate
        public ActionResult PortfolyoEdit(int id)
        {
            var values = _portfolyoService.TGetByID(id);
            return View("PortfolyoEdit", values);
        }

        [HttpPost]
        public ActionResult PortfolyoUpdate(Portfolyo p)
        {
            try
            {
                var updatedPortfolyo = _portfolyoService.TGetByID(p.PortfolyoID);

                updatedPortfolyo.HeadingName = p.HeadingName;
                updatedPortfolyo.Image = p.Image;
                updatedPortfolyo.GitHubUrl = p.GitHubUrl;
                updatedPortfolyo.Status = p.Status;
                _portfolyoService.TUpdate(updatedPortfolyo);
                return RedirectToAction("Portfolyo");
            }
            catch (ValidationException ex)
            {
                var errormessage = string.Join("<br>", ex.Errors.Select(x => x.ErrorMessage));
                TempData["Error"] = errormessage;
                TempData["RedirectUrl"] = Url.Action("Portfolyo", "Admin");
                return RedirectToAction("ErrorPageForAdminPages", "ErrorPages");
            }
        }
        #endregion

        #endregion

        #region PortfolyoImageOperation

        #region List
        public ActionResult PortfolyoImages()
        {
            #region GetPortfolyoHeading
            var getvalues = context.Portfolyos.Select(x => new SelectListItem
            {
                Value = x.PortfolyoID.ToString(),
                Text = x.HeadingName
            }).ToList();
            ViewBag.PortfolyoHeading = getvalues;

            #endregion

            var values = _portfolyoImagesService.TGetImagesByPortfolyoID();
            return View(values);
        }
        #endregion

        #region Add

        [HttpPost]
        public ActionResult PortfolyoImagesAdd(PortfolyoImages p)
        {
            var uploadedFile = Request.Files["Image"];
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                var resource = Server.MapPath("~/Content/images/KısıselCV");
                var extension = Path.GetExtension(uploadedFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resource, imageName);

                // Delete old image if exists
                if (!string.IsNullOrEmpty(p.Images))
                {
                    var oldImagePath = Server.MapPath(p.Images);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                uploadedFile.SaveAs(saveLocation);
                p.Images = "/Content/images/KısıselCV/" + imageName;
            }
            p.Status = true;
            _portfolyoImagesService.TInsert(p);
            return RedirectToAction("PortfolyoImages");
        }

        #endregion

        #region Delete

        public ActionResult PortfolyoImagesDelete(int id)
        {
            var values = _portfolyoImagesService.TGetByID(id);
            values.Status = false;
            _portfolyoImagesService.TUpdate(values);
            return RedirectToAction("PortfolyoImages");
        }

        #endregion

        public ActionResult ViewsImages(int id)
        {
            var values = _portfolyoImagesService.TGetAllListImagesByPortfolyoID(id);
            return View(values);
        }

        #endregion

        #region Contact

        #region List

        public PartialViewResult LeftBarArea()
        {
            var values = context.Contacts.Count();
            @ViewBag.ınboxcount = values;
            return PartialView();
        }

        public ActionResult ContactDetails(int id)
        {
            if (!User.IsInRole("1"))
            {
                TempData["Error"] = "Bu sayfayı görüntüleme yetkisine sahip değilsiniz";
                return RedirectToAction("ErrorPageForRolePermission", "ErrorPages");
            }
            var getcontactdetails = _contactService.TGetByID(id);
            return View(getcontactdetails);
        }

        public ActionResult Contact()
        {
            var values = _contactService.TGetAllList();
            return View(values);
        }
        #endregion

        #endregion

    }
}