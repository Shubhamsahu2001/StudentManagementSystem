namespace StudentManagement.API.DTOs.StudentSubjects
{
    public class EnrollStudentDto
    {
        public int StudentId { get; set; }

        public List<int> SubjectIds { get; set; } = new();
    }
}
        
    

