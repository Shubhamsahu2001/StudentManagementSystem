namespace StudentManagement.API.Models
{
    public class StudentSubject
    {
        public int StudentSubjectId { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        // Navigation Properties

        public Student Student { get; set; } = null!;

        public Subject Subject { get; set; } = null!;
    }
}