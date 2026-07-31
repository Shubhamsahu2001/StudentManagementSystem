namespace StudentManagement.API.DTOs.StudentSubjects
{
    public class StudentDetailsDto
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        public string Address { get; set; } = string.Empty;

        public List<string> Subjects { get; set; } = new();
    }
}