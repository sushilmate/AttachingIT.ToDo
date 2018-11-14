using AttachingITToDo.Domain;
using System.Collections.Generic;

namespace AttachingITToDo.Persistence.Repository
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        IEnumerable<ToDo> GetAllToDos();

        bool UpdateToDos(IEnumerable<ToDo> ToDos);

        void DeleteToDos(IEnumerable<ToDo> toDos);
        void CreateOrUpdate(IEnumerable<ToDo> enumerable);
    }
}