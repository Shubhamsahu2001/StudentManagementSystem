namespace StudentManagement.API.DTOs.Students
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string? Address { get; set; }

        public string? PhotoPath { get; set; }
    }
}