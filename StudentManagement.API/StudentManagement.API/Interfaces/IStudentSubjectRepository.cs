using StudentManagement.API.DTOs.StudentSubjects;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentSubjectRepository
    {
        Task EnrollStudentAsync(EnrollStudentDto enrollStudentDto);

        Task<List<EnrollmentListDto>> GetAllEnrollmentsAsync();
        Task<StudentDetailsDto?> GetStudentDetailsAsync(int studentId);
    }
}
