namespace AttachingITToDo.Persistence.Repository
{
    using System.Collections.Generic;

    public interface IRepository<T> where T : class
    {
        void Create(IEnumerable<T> entities);

        void Delete(IEnumerable<T> entities);

        IEnumerable<T> GetAll();

        T Get(int id);

        bool Update(T entity);

        bool UpdateAll(IEnumerable<T> entities);
    }
}