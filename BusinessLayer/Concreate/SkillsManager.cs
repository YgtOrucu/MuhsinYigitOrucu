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
    public class SkillsManager : ISkillsService
    {
        private readonly ISkillsDal _skillsDal;
        private readonly SkillsValidation _validationRulesSkills;
        public SkillsManager(ISkillsDal skillsDal, SkillsValidation validationRulesSkills)
        {
            _skillsDal = skillsDal;
            _validationRulesSkills = validationRulesSkills;
        }

        public List<Skills> TGetAllList()
        {
            return _skillsDal.GetAllList();
        }

        public Skills TGetByID(int id)
        {
            return _skillsDal.GetByID(id);
        }

        public List<Skills> TGetListByFilter(Expression<Func<Skills, bool>> filter)
        {
            return _skillsDal.GetListByFilter(filter);
        }

        public void TInsert(Skills entity)
        {
            var result = _validationRulesSkills.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _skillsDal.Insert(entity);
        }

        public void TUpdate(Skills entity)
        {
            var result = _validationRulesSkills.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _skillsDal.Update(entity);
        }
    }
}
