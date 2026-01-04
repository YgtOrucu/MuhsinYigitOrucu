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
    public class EFPortfolyoImagesDal : GenericRepository<PortfolyoImages>, IPortfolyoImagesDal
    {
        MYOContext context = new MYOContext();

        public List<PortfolyoImages> GetActiveForUsersPage()
        {
            return context.PortfolyoImages.Where(x => x.Status == true).ToList();
        }

        public List<PortfolyoImages> GetAllListImagesByPortfolyoID(int id)
        {
            return context.PortfolyoImages.Where(x => x.PortfolyoID == id && x.Status == true).ToList();
        }

        public List<GetImagesByPortfolyoID> GetImagesByPortfolyoID()
        {
            var values = context.PortfolyoImages
                .Where(i => i.Images != null && i.Status == true)
                .GroupBy(i => i.Portfolyo)
                .Select(g => new GetImagesByPortfolyoID
                {
                    PortfolyoID = g.Key.PortfolyoID,
                    HeadingName = g.Key.HeadingName,
                    Images = g.Select(x => x.Images).ToList()
                })
                .ToList();

            return values;
        }

        public List<string> GetPortfolyoImagesByPortfolyoID(int id)
        {
            var images = context.PortfolyoImages
                                 .Where(x => x.PortfolyoID == id && x.Status == true)
                                 .Select(x => x.Images)
                                 .ToList();

            return images;
        }
    }
}
