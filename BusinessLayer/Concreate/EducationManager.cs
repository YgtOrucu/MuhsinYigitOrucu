using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BusinessLayer.Validations;

namespace BusinessLayer.Concreate
{
    public class EducationManager : IGenericService<Education>
    {
        private readonly IEducationDal _educationDal;
        private readonly EducationValidation _validationRulesEducation;

        public EducationManager(IEducationDal educationDal, EducationValidation validationRulesEducation)
        {
            _educationDal = educationDal;
            _validationRulesEducation = validationRulesEducation;
        }


        public List<Education> TGetAllList()
        {
            return _educationDal.GetAllList();
        }

        public Education TGetByID(int id)
        {
            return _educationDal.GetByID(id);
        }

        public List<Education> TGetListByFilter(Expression<Func<Education, bool>> filter)
        {
            return _educationDal.GetListByFilter(filter);
        }

        public void TInsert(Education entity)
        {
            var result = _validationRulesEducation.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _educationDal.Insert(entity);
        }

        public void TUpdate(Education entity)
        {
            var result = _validationRulesEducation.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _educationDal.Update(entity);
        }
    }
}
