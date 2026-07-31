using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.DTOs.Subjects
{
    public class UpdateSubjectDto
    {
        [Required]
        public int SubjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? FacultyName { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }
    }
}