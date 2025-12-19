using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GenericRepo
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly MYOContext context = new MYOContext();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }
        public List<T> GetAllList()
        {
            return _object.ToList();
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            _object.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updateded = context.Entry(entity);
            updateded.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
