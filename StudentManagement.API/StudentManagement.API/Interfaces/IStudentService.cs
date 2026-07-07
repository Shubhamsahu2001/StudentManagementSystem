using StudentManagement.API.DTOs.Students;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();

        Task<StudentDto?> GetStudentByIdAsync(int id);

        Task<StudentDto> AddStudentAsync(CreateStudentDto studentDto);

        Task<StudentDto?> UpdateStudentAsync(UpdateStudentDto studentDto);

        Task<bool> DeleteStudentAsync(int id);
    }
}