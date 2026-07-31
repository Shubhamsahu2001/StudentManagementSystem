using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.DTOs.StudentSubjects;
using StudentManagement.API.Interfaces;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IStudentSubjectService _studentSubjectService;

        public StudentSubjectController(IStudentSubjectService studentSubjectService)
        {
            _studentSubjectService = studentSubjectService;
        }

        [HttpPost("enroll")]
        public async Task<IActionResult> EnrollStudent(EnrollStudentDto enrollStudentDto)
        {
            await _studentSubjectService.EnrollStudentAsync(enrollStudentDto);

            return Ok(new
            {
                message = "Student enrolled successfully."
            });
        }

        [HttpGet("enrollments")]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var enrollments = await _studentSubjectService.GetAllEnrollmentsAsync();

            return Ok(enrollments);
        }


        [HttpGet("student-details/{id}")]
        public async Task<IActionResult> GetStudentDetails(int id)
        {
            var student = await _studentSubjectService.GetStudentDetailsAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
    }
}