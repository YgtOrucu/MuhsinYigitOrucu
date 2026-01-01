using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Context;
using DataAccessLayer.EFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuhsinYigitÖrücü.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
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

        public UsersController()
        {
            _adminService = new AdminManager(new EFAdminDal(), new AdminValidation());
            _aboutService = new AboutManager(new EFAboutDal(), new AboutValidations());
            _educationService = new EducationManager(new EFEducationDal(), new EducationValidation());
            _experienceService = new ExperienceManager(new EFExperienceDal(), new ExperienceValidation());
            _roleService = new RoleManager(new EFRoleDal());
            _socialMediaService = new SocialMediaManager(new EFSocialMediaDal());
            _skillsService = new SkillsManager(new EFSkillsDal(), new SkillsValidation());
            _portfolyoService = new PortfolyoManager(new EFPortfolyoDal(), new PortfolyoValidation());
            _portfolyoImagesService = new PortfolyoImagesManager(new EFPortfolyoImagesDal());
        }
        #endregion

        public ActionResult HomePage()
        {
            if (!User.IsInRole("1"))
            {
                return RedirectToAction("ErrorPageForRolePermission", "ErrorPages");
            }
            else
            {
               return View();
            }
        }


        public PartialViewResult About()
        {
            var values = _aboutService.TGetActiveForUsersPage();
            return PartialView(values);
        }

        public PartialViewResult Skills()
        {
            var values = _skillsService.TGetActiveForUsersPage();
            return PartialView(values);
        }

        public PartialViewResult Experience()
        {
            var values = _experienceService.TGetActiveForUsersPage();
            return PartialView(values);
        } //Daha sonra tamamlanacak

        public PartialViewResult Portfolyo()
        {
            var values = _portfolyoService.tGetActiveForUsersPage();
            return PartialView(values);
        }
    }
}