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

        public List<PortfolyoImages> GetAllListImagesByPortfolyoID(int id)
        {
            return context.PortfolyoImages.Where(x => x.PortfolyoID == id && x.Status == true).ToList();
        }

        public List<GetImagesByPortfolyoID> GetImagesByPortfolyoID()
        {
            var values = context.PortfolyoImages
                .Where(i => i.Images != null)
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

    }
}
