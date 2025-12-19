using DataAccessLayer.Abstract;
using DataAccessLayer.GenericRepo;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EFramework
{
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
    }
}
