using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Validations;

namespace BusinessLayer.Concreate
{
    public class AboutManager : IAboutService
    {
        #region Construction
        private readonly IAboutDal _aboutDal;
        private readonly AboutValidations _validationRulesAbout;

        public AboutManager(IAboutDal aboutDal, AboutValidations validationRulesAbout)
        {
            _aboutDal = aboutDal;
            _validationRulesAbout = validationRulesAbout;
        }
        #endregion 
        public List<About> TGetAllList()
        {
            return _aboutDal.GetAllList();
        }

        public About TGetByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> TGetListByFilter(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.GetListByFilter(filter);
        }

        public void TInsert(About entity)
        {
            var result = _validationRulesAbout.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _aboutDal.Insert(entity);
        }

        public void TUpdate(About entity)
        {
            var result = _validationRulesAbout.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _aboutDal.Update(entity);
        }
    }
}
