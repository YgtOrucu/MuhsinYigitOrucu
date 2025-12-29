using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.GenericRepo;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EFramework
{
    public class EFExperienceDal : GenericRepository<Experience>, IExperienceDal
    {
        MYOContext c = new MYOContext();

        public List<Experience> GetActiveForUsersPage()
        {
            return c.Experiences.Where(x => x.Status == true).ToList();
        }
    }
}
