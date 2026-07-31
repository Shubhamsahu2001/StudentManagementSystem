namespace StudentManagement.API.DTOs.Subjects
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; } = string.Empty;

        public string? FacultyName { get; set; }

        public string? Description { get; set; }
    }
}