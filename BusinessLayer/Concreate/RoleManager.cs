using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> TGetAllList()
        {
            return _roleDal.GetAllList();
        }

        public Role TGetByID(int id)
        {
            return _roleDal.GetByID(id);
        }

        public List<Role> TGetListByFilter(Expression<Func<Role, bool>> filter)
        {
            return _roleDal.GetListByFilter(filter);
        }

        public List<GetMembersImageByRoleID> TGetMembersImageByRole()
        {
            return _roleDal.GetMembersImageByRole();
        }

        public void TInsert(Role entity)
        {
            _roleDal.Insert(entity);
        }

        public void TUpdate(Role entity)
        {
            _roleDal.Update(entity);
        }
    }
}
