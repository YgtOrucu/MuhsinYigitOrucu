using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.GenericRepo;
using EntityLayer.Concreate;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EFramework
{
    public class EFRoleDal : GenericRepository<Role>, IRoleDal
    {
        MYOContext c = new MYOContext();
        public List<GetMembersImageByRoleID> GetMembersImageByRole()
        {
            var roles = c.Roles
                        .Select(r => new GetMembersImageByRoleID
                        {
                            RoleID = r.RoleID,
                            RoleType = r.RoleType,
                            Images = c.Admins
                                      .Where(a => a.RoleID == r.RoleID && a.Image != null)
                                      .Select(a => a.Image)
                                      .ToList()
                        })
                        .ToList();
            return roles;
        }
    }
}
