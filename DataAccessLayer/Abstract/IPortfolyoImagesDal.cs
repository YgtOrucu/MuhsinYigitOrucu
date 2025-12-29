using EntityLayer.Concreate;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPortfolyoImagesDal : IGenericDal<PortfolyoImages>
    {
        List<GetImagesByPortfolyoID> GetImagesByPortfolyoID();

        List<PortfolyoImages> GetAllListImagesByPortfolyoID(int id);

        List<PortfolyoImages> GetActiveForUsersPage();
    }
}
