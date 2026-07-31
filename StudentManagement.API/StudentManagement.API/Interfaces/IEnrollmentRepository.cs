using StudentManagement.API.DTOs.StudentSubjects;

public interface IEnrollmentRepository
{
    Task<List<EnrollmentListDto>> GetAllEnrollmentsAsync();
}