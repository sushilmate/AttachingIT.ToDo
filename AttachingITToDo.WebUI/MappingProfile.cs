using AttachingITToDo.Application.VideModels;
using AttachingITToDo.Domain;
using AutoMapper;

namespace AttachingITToDo.WebUI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDo, ToDoViewModel>();
            CreateMap<ToDoViewModel, ToDo>();
        }
    }
}