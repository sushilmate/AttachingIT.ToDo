using AttachingITToDo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AttachingITToDo.Persistence.Repository
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        public ToDoRepository(AttachingITContext context) : base(context)
        {
        }

        public IEnumerable<ToDo> GetAllToDos()
        {
            return _context.ToDo;
        }

        public bool UpdateToDos(IEnumerable<ToDo> ToDos)
        {
            _context.ToDo.UpdateRange(ToDos);
            Save();
            return true;
        }
        public void CreateToDos(IEnumerable<ToDo> entities)
        {
            if (entities.Count() == 0)
                return;

            _context.ToDo.AddRange(entities);
            Save();
        }
        public void DeleteToDos(IEnumerable<ToDo> toDos)
        {
            _context.ToDo.RemoveRange(toDos);
            Save();
        }

        public void CreateOrUpdate(IEnumerable<ToDo> toDos)
        {
            var modifiedToDos = toDos.Where(x => x.Id != null && x.Id.Value != 0);
            var newToDos = toDos.Where(x => x.Id == null || x.Id.Value == 0);
            UpdateToDos(modifiedToDos);
            Create(newToDos);
        }
    }
}