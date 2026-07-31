using StudentManagement.API.DTOs.StudentSubjects;
using StudentManagement.API.Interfaces;

namespace StudentManagement.API.Services
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly IStudentSubjectRepository _studentSubjectRepository;

        public StudentSubjectService(IStudentSubjectRepository studentSubjectRepository)
        {
            _studentSubjectRepository = studentSubjectRepository;
        }

        public async Task EnrollStudentAsync(EnrollStudentDto enrollStudentDto)
        {
            await _studentSubjectRepository.EnrollStudentAsync(enrollStudentDto);
        }

        public async Task<List<EnrollmentListDto>> GetAllEnrollmentsAsync()
        {
            return await _studentSubjectRepository.GetAllEnrollmentsAsync();
        }

        public async Task<StudentDetailsDto?> GetStudentDetailsAsync(int studentId)
        {
            return await _studentSubjectRepository.GetStudentDetailsAsync(studentId);
        }
    }
}