using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Context;
using DataAccessLayer.EFramework;
using EntityLayer.Concreate;
using MuhsinYigitÖrücü.Models;
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
        private readonly IAboutService _aboutService;
        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly ISkillsService _skillsService;
        private readonly IPortfolyoService _portfolyoService;
        private readonly IPortfolyoImagesService _portfolyoImagesService;
        private readonly IContactService _contactService;

        public UsersController()
        {
            _aboutService = new AboutManager(new EFAboutDal(), new AboutValidations());
            _educationService = new EducationManager(new EFEducationDal(), new EducationValidation());
            _experienceService = new ExperienceManager(new EFExperienceDal(), new ExperienceValidation());
            _socialMediaService = new SocialMediaManager(new EFSocialMediaDal());
            _skillsService = new SkillsManager(new EFSkillsDal(), new SkillsValidation());
            _portfolyoService = new PortfolyoManager(new EFPortfolyoDal(), new PortfolyoValidation());
            _portfolyoImagesService = new PortfolyoImagesManager(new EFPortfolyoImagesDal());
            _contactService = new ContactManager(new EFContactDal());
        }
        #endregion

        public ActionResult HomePage()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult About()
        {
            var values = _aboutService.TGetActiveForUsersPage();
            return PartialView(values);
        }

        [ChildActionOnly]
        public PartialViewResult Skills()
        {
            var values = _skillsService.TGetActiveForUsersPage();
            return PartialView(values);
        }

        [ChildActionOnly]
        public PartialViewResult Experience()
        {
            JobAndExperienceForUsersPage jobAndExperience = new JobAndExperienceForUsersPage
            {
                Educations = _educationService.tGetActiveForUsersPage(),
                Experiences = _experienceService.TGetActiveForUsersPage()
            };
            return PartialView(jobAndExperience);
        }

        [ChildActionOnly]
        public PartialViewResult Portfolyo()
        {
            var values = _portfolyoService.tGetActiveForUsersPage();
            return PartialView(values);
        }

        public ActionResult GetPortfolyoImages(int id)
        {
            var images = _portfolyoImagesService.TGetPortfolyoImagesByPortfolyoID(id);
            return Json(images, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public PartialViewResult Contact()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Contact(Contact c)
        {
            _contactService.TInsert(c);
            return RedirectToAction("HomePage");
        }

        [ChildActionOnly]
        public PartialViewResult LoginPage()
        {
            return PartialView();
        }

        public ActionResult ViewCv()
        {
            var path = Server.MapPath("~/Content/CV/MuhsinYiğitÖrücüCV.pdf");
            return File(path, "application/pdf");
        }
    }
}