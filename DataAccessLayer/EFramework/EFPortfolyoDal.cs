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
    public class EFPortfolyoDal : GenericRepository<Portfolyo>, IPortfolyoDal
    {
        MYOContext c = new MYOContext();

        public List<Portfolyo> GetActiveForUsersPage()
        {
            return c.Portfolyos.Where(x => x.Status == true).ToList();
        }
    }
}
