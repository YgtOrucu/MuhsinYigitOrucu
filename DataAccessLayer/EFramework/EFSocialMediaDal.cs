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
    public class EFSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        MYOContext c = new MYOContext();

        public List<SocialMedia> GetActiveForUsersPage()
        {
            return c.SocialMedias.Where(x => x.Status == true).ToList();
        }
    }
}
