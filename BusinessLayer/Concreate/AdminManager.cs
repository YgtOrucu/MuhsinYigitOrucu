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
    public class AdminManager : IGenericService<Admin>
    {
        private readonly IAdminDal _adminDal;
        private readonly AdminValidation _validationRulesAdmin;
        public AdminManager(IAdminDal adminDal, AdminValidation validationRulesAdmin)
        {
            _adminDal = adminDal;
            _validationRulesAdmin = validationRulesAdmin;
        }
        public List<Admin> TGetAllList()
        {
            return _adminDal.GetAllList();
        }

        public Admin TGetByID(int id)
        {
            return _adminDal.GetByID(id);
        }

        public List<Admin> TGetListByFilter(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.GetListByFilter(filter);
        }

        public void TInsert(Admin entity)
        {
            var result = _validationRulesAdmin.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _adminDal.Insert(entity);
        }

        public void TUpdate(Admin entity)
        {
            var result = _validationRulesAdmin.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _adminDal.Update(entity);
        }
    }
}
