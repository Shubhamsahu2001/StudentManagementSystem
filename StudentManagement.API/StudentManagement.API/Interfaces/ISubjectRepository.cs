using StudentManagement.API.DTOs.Subjects;
using StudentManagement.API.Models;

namespace StudentManagement.API.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();

        Task<Subject?> GetSubjectByIdAsync(int id);

        Task<Subject> AddSubjectAsync(Subject subject);

        Task<Subject?> UpdateSubjectAsync(Subject subject);

        Task<bool> DeleteSubjectAsync(int id);
    }
}