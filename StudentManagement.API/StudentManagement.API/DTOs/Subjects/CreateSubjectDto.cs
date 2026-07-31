using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.DTOs.Subjects
{
    public class CreateSubjectDto
    {
        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? FacultyName { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }
    }
}