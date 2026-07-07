using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? FacultyName { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }

        // Navigation Property
        public ICollection<StudentSubject> StudentSubjects { get; set; }
            = new List<StudentSubject>();
    }
}