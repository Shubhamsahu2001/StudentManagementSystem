using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.DTOs.Students
{
    public class CreateStudentDto
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string? Address { get; set; }

        public string? PhotoPath { get; set; }
    }
}