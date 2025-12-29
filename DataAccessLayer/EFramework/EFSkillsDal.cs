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
    public class EFSkillsDal : GenericRepository<Skills>, ISkillsDal
    {
        MYOContext c = new MYOContext();

        public List<Skills> GetActiveForUsersPage()
        {
            return c.Skills.Where(x => x.Status == true).ToList();
        }
    }
}
