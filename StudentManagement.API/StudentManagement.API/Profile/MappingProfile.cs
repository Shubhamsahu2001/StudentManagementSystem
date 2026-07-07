using AutoMapper;
using StudentManagement.API.DTOs.Students;
using StudentManagement.API.Models;

namespace StudentManagement.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();

            CreateMap<CreateStudentDto, Student>();

            CreateMap<UpdateStudentDto, Student>();

            CreateMap<Student, UpdateStudentDto>();
        }
    }
}