namespace StudentManagement.API.DTOs.StudentSubjects
{
    public class EnrollmentListDto
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public int SubjectId { get; set; }

        public string SubjectName { get; set; } = string.Empty;
    }
}