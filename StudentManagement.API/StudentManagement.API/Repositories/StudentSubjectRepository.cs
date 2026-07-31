using StudentManagement.API.Data;
using StudentManagement.API.DTOs.StudentSubjects;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.API.Repositories
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentSubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EnrollStudentAsync(EnrollStudentDto enrollStudentDto)
        {
            // Get existing subject enrollments for the student
            var existingEnrollments = await _context.StudentSubjects
                .Where(ss => ss.StudentId == enrollStudentDto.StudentId)
                .ToListAsync();

            // Remove old enrollments
            _context.StudentSubjects.RemoveRange(existingEnrollments);

            // Add newly selected subjects
            foreach (var subjectId in enrollStudentDto.SubjectIds)
            {
                _context.StudentSubjects.Add(new StudentSubject
                {
                    StudentId = enrollStudentDto.StudentId,
                    SubjectId = subjectId
                });
            }

            // Save changes to database
            await _context.SaveChangesAsync();
        }

        public async Task<List<EnrollmentListDto>> GetAllEnrollmentsAsync()
        {
            return await _context.StudentSubjects
                .Select(ss => new EnrollmentListDto
                {
                    StudentId = ss.StudentId,
                    StudentName = ss.Student.FirstName + " " + ss.Student.LastName,

                    SubjectId = ss.SubjectId,
                    SubjectName = ss.Subject.SubjectName
                })
                .ToListAsync();
        }

        public async Task<StudentDetailsDto?> GetStudentDetailsAsync(int studentId)
        {
            var student = await _context.Students
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                return null;
            }

            return new StudentDetailsDto
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone,
                Gender = student.Gender,
                DOB =  (DateTime)student.DOB,
                Address = student.Address,

                Subjects = student.StudentSubjects
                    .Select(ss => ss.Subject.SubjectName)
                    .ToList()
            };
        }
    }
}