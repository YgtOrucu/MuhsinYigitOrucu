using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.GenericRepo;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EFramework
{
    public class EFAdminDal : GenericRepository<Admin>, IAdminDal
    {
        MYOContext context = new MYOContext();
        public List<Admin> GetAdminByRoleID(int id)
        {
            return context.Admins.Where(x => x.RoleID == id).ToList();
        }
    }
}
