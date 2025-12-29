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
    public class EFEducationDal : GenericRepository<Education>, IEducationDal
    {
        MYOContext c = new MYOContext();

        public List<Education> GetActiveForUsersPage()
        {
            return c.Educations.Where(x => x.Status == true).ToList();
        }
    }
}
