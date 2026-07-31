using AutoMapper;
using StudentManagement.API.DTOs.Students;
using StudentManagement.API.DTOs.Subjects;
using StudentManagement.API.Models;

namespace StudentManagement.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Student Mapping
            CreateMap<Student, StudentDto>();

            CreateMap<CreateStudentDto, Student>();

            CreateMap<UpdateStudentDto, Student>();

            CreateMap<Student, UpdateStudentDto>();

            //Subject Mapping

            // Subject Mappings
            CreateMap<Subject, SubjectDto>();
            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<UpdateSubjectDto, Subject>();
            CreateMap<Subject, UpdateSubjectDto>();
        }
    }
}