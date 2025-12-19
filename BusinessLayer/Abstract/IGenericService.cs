using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetAllList();
        void TInsert(T entity);
        void TUpdate(T entity);
        T TGetByID(int id);
        List<T> TGetListByFilter(Expression<Func<T, bool>> filter);
    }
}
