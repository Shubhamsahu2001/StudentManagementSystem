using StudentManagement.API.Models;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<Student?> GetStudentByIdAsync(int id);

        Task<Student> AddStudentAsync(Student student);

        Task<Student?> UpdateStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(int id);
    }
}