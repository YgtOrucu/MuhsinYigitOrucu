using EntityLayer.Concreate;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPortfolyoImagesService : IGenericService<PortfolyoImages>
    {
        List<GetImagesByPortfolyoID> TGetImagesByPortfolyoID();

        List<PortfolyoImages> TGetAllListImagesByPortfolyoID(int id);
        List<PortfolyoImages> TGetActiveForUsersPage();
        List<string> TGetPortfolyoImagesByPortfolyoID(int id);

    }
}
