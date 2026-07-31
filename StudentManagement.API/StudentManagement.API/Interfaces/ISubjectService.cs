using StudentManagement.API.DTOs.Subjects;

namespace StudentManagement.API.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();

        Task<SubjectDto?> GetSubjectByIdAsync(int id);

        Task<SubjectDto> AddSubjectAsync(CreateSubjectDto subjectDto);

        Task<SubjectDto?> UpdateSubjectAsync(UpdateSubjectDto subjectDto);

        Task<bool> DeleteSubjectAsync(int id);
    }
}