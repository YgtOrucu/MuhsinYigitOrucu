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
    public class PortfolyoManager : IGenericService<Portfolyo>
    {
        private readonly IPortfolyoDal _portfolyoDal;
        private readonly PortfolyoValidation _validationRulesPortfolyo;
        public PortfolyoManager(IPortfolyoDal portfolyoDal, PortfolyoValidation validationRulesPortfolyo)
        {
            _portfolyoDal = portfolyoDal;
            _validationRulesPortfolyo = validationRulesPortfolyo;
        }

        public List<Portfolyo> TGetAllList()
        {
            return _portfolyoDal.GetAllList();
        }

        public Portfolyo TGetByID(int id)
        {
            return _portfolyoDal.GetByID(id);
        }

        public List<Portfolyo> TGetListByFilter(Expression<Func<Portfolyo, bool>> filter)
        {
            return _portfolyoDal.GetListByFilter(filter);
        }

        public void TInsert(Portfolyo entity)
        {
            var result = _validationRulesPortfolyo.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _portfolyoDal.Insert(entity);
        }

        public void TUpdate(Portfolyo entity)
        {
            var result = _validationRulesPortfolyo.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _portfolyoDal.Update(entity);
        }
    }
}
