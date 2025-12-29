using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDal _experienceDal;
        private readonly ExperienceValidation _validationRulesExperience;
        public ExperienceManager(IExperienceDal experienceDal, ExperienceValidation validationRulesExperience)
        {
            _experienceDal = experienceDal;
            _validationRulesExperience = validationRulesExperience;
        }

        public List<Experience> TGetActiveForUsersPage()
        {
            return _experienceDal.GetActiveForUsersPage();
        }

        public List<Experience> TGetAllList()
        {
            return _experienceDal.GetAllList();
        }

        public Experience TGetByID(int id)
        {
            return _experienceDal.GetByID(id);
        }

        public List<Experience> TGetListByFilter(Expression<Func<Experience, bool>> filter)
        {
            return _experienceDal.GetListByFilter(filter);
        }

        public void TInsert(Experience entity)
        {
            var result = _validationRulesExperience.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _experienceDal.Insert(entity);
        }

        public void TUpdate(Experience entity)
        {
            var result = _validationRulesExperience.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _experienceDal.Update(entity);
        }
    }
}
