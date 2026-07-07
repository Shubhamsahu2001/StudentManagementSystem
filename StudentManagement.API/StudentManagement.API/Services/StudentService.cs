using AutoMapper;
using StudentManagement.API.DTOs.Students;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;

namespace StudentManagement.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null)
                return null;

            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> AddStudentAsync(CreateStudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            var createdStudent = await _studentRepository.AddStudentAsync(student);

            return _mapper.Map<StudentDto>(createdStudent);
        }

        public async Task<StudentDto?> UpdateStudentAsync(UpdateStudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            var updatedStudent = await _studentRepository.UpdateStudentAsync(student);

            if (updatedStudent == null)
                return null;

            return _mapper.Map<StudentDto>(updatedStudent);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _studentRepository.DeleteStudentAsync(id);
        }
    }
}