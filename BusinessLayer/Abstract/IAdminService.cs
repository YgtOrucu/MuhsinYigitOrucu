using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService : IGenericService<Admin>
    {
        List<Admin> TGetAdminByRoleID(int id);
        List<Admin> TCheckAdminForLogin(string mail, string password);

    }
}
