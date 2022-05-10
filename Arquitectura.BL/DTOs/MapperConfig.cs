using Arquitectura.BL.Models;
using AutoMapper;

namespace Arquitectura.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                #region 
                cfg.CreateMap<Course, CourseDTO>(); //GET
                cfg.CreateMap<CourseDTO, Course>(); //POST - PUT
                cfg.CreateMap<Instructor, InstructorDTO>();
                cfg.CreateMap<InstructorDTO, Instructor>();
                cfg.CreateMap<CourseInstructor, CourseInstructorDTO>();
                cfg.CreateMap<CourseInstructorDTO, CourseInstructor>();
                #endregion
                //State
                cfg.CreateMap<State, StateDTO>();
                cfg.CreateMap<StateDTO, State>();
                //Priority
                cfg.CreateMap<Priority, PriorityDTO>();
                cfg.CreateMap<PriorityDTO, Priority>();
                //Document
                cfg.CreateMap<DocumentType, DocumentTypeDTO>();
                cfg.CreateMap<DocumentTypeDTO, DocumentType>();
                //Customer
                cfg.CreateMap<Customer, InputCustomerDTO>().ReverseMap();
                cfg.CreateMap<Customer,OutputCustomerDTO > ().ReverseMap();
                //Developer
                cfg.CreateMap<Developer, InputDeveloperDTO>().ReverseMap();
                cfg.CreateMap<Developer, OutputDeveloperDTO>().ReverseMap();
                //Requirement
                cfg.CreateMap<Requirement, InputRequirementDTO>().ReverseMap();
                cfg.CreateMap<Requirement, OutputRequirementDTO>().ReverseMap();
                //Project
                cfg.CreateMap<Project, InputProjectDTO>().ReverseMap();
                cfg.CreateMap<Project, OutputProjectDTO>().ReverseMap();
            });
        }
    }
}
