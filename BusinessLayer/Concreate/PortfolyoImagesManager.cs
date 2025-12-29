using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class PortfolyoImagesManager : IPortfolyoImagesService
    {
        private readonly IPortfolyoImagesDal _portfolyoImagesDal;
        public PortfolyoImagesManager (IPortfolyoImagesDal portfolyoImagesDal)
        {
            _portfolyoImagesDal = portfolyoImagesDal;
        }
        public List<PortfolyoImages> TGetAllList()
        {
            return _portfolyoImagesDal.GetAllList();
        }

        public List<PortfolyoImages> TGetAllListImagesByPortfolyoID(int id)
        {
            return _portfolyoImagesDal.GetAllListImagesByPortfolyoID(id);
        }

        public PortfolyoImages TGetByID(int id)
        {
            return _portfolyoImagesDal.GetByID(id);
        }

        public List<GetImagesByPortfolyoID> TGetImagesByPortfolyoID()
        {
            return _portfolyoImagesDal.GetImagesByPortfolyoID();
        }

        public List<PortfolyoImages> TGetListByFilter(Expression<Func<PortfolyoImages, bool>> filter)
        {
            return _portfolyoImagesDal.GetListByFilter(filter);
        }

        public void TInsert(PortfolyoImages entity)
        {
            _portfolyoImagesDal.Insert(entity);
        }

        public void TUpdate(PortfolyoImages entity)
        {
            _portfolyoImagesDal.Update(entity);
        }
    }
}
