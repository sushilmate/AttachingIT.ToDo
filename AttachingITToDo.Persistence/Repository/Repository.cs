using System;
using System.Collections.Generic;
using System.Linq;

namespace AttachingITToDo.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AttachingITContext _context;

        public Repository(AttachingITContext context)
        {
            _context = context;
        }

        protected void Save()
        {
            _context.SaveChanges();
        }

        public void Create(IEnumerable<T> entities)
        {
            if (entities.Count() == 0)
                return;

            _context.AddRange(entities);
            Save();
        }

        public void Delete(IEnumerable<T> entities)
        {
            if (entities.Count() == 0)
                return;

            _context.Remove(entities);
            Save();
        }

        public bool Update(T entity)
        {
            if (entity == null)
                return false;

            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateAll(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}