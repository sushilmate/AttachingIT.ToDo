using AttachingITToDo.Application.VideModels;
using AttachingITToDo.Domain;
using AttachingITToDo.Persistence.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AttachingITToDo.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class ToDoDataController : Controller
    {
        private readonly IMapper _mapper;

        public ToDoDataController(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        private IToDoRepository _toDoRepository;

        [HttpGet("[action]")]
        public IEnumerable<ToDoViewModel> GetAllToDoItems()
        {
            var toDos = _toDoRepository.GetAllToDos();
            return _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoViewModel>>(toDos);
        }

        [HttpPost("[action]")]
        public bool AddToDo([FromBody] IEnumerable<ToDoViewModel> toDo)
        {
            if (toDo == null)
            {
                return false;
                //return BadRequest("Invalid passed data");
            }

            if (!ModelState.IsValid)
            {
                return false;
                // return BadRequest(ModelState);
            }
            try
            {
                _toDoRepository.Create(_mapper.Map<IEnumerable<ToDoViewModel>, IEnumerable<ToDo>>(toDo));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("[action]")]
        public bool RemoveToDo([FromBody] IEnumerable<ToDoViewModel> toDo)
        {
            if (toDo == null)
            {
                return false;
                //return BadRequest("Invalid passed data");
            }

            if (!ModelState.IsValid)
            {
                return false;
                // return BadRequest(ModelState);
            }
            try
            {
                _toDoRepository.DeleteToDos(_mapper.Map<IEnumerable<ToDoViewModel>, IEnumerable<ToDo>>(toDo));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("[action]")]
        public IEnumerable<ToDoViewModel> UpdateOrAddToDo([FromBody] IEnumerable<ToDoViewModel> toDo)
        {
            if (toDo == null || toDo.Count() == 0)
            {
                return null;
                //return BadRequest("Invalid passed data");
            }

            if (!ModelState.IsValid)
            {
                return null;
                // return BadRequest(ModelState);
            }
            try
            {
                _toDoRepository.CreateOrUpdate(_mapper.Map<IEnumerable<ToDoViewModel>, IEnumerable<ToDo>>(toDo));
                var toDos = _toDoRepository.GetAllToDos();
                return _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoViewModel>>(toDos);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}