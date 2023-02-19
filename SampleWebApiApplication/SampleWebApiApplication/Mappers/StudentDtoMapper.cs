using AutoMapper;
using WebApp.Models.Dto;
using WebApp.Models.Models;

namespace SampleWebApiApplication.Mappers
{
    public class StudentDtoMapper : Profile
    {
        public StudentDtoMapper()
        {
            CreateMap<Student, StudentDto>().ForMember(x => x.Department,
                opt => opt.MapFrom
                    (src => src.Department.DepartmentName)).ReverseMap();
        }
    }
}