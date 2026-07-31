using Microsoft.EntityFrameworkCore;
using StudentManagement.API.Data;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;

namespace StudentManagement.API.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Student)
                .ToListAsync();
        }

        public async Task<Subject?> GetSubjectByIdAsync(int id)
        {
            return await _context.Subjects
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Student)
                .FirstOrDefaultAsync(s => s.SubjectId == id);
        }

        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject?> UpdateSubjectAsync(Subject subject)
        {
            var existingSubject = await _context.Subjects.FindAsync(subject.SubjectId);

            if (existingSubject == null)
                return null;

            existingSubject.SubjectName = subject.SubjectName;
            existingSubject.FacultyName = subject.FacultyName;
            existingSubject.Description = subject.Description;

            await _context.SaveChangesAsync();

            return existingSubject;
        }
        
        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                return false;
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }


    }

}