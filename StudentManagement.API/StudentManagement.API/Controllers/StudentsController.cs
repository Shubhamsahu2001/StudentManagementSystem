using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.DTOs.Students;
using StudentManagement.API.Interfaces;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentDto studentDto)
        {
            var createdStudent = await _studentService.AddStudentAsync(studentDto);

            return CreatedAtAction(
                nameof(GetStudentById),
                new { id = createdStudent.StudentId },
                createdStudent);
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto studentDto)
        {
            if (id != studentDto.StudentId)
                return BadRequest();

            var updatedStudent = await _studentService.UpdateStudentAsync(studentDto);

            if (updatedStudent == null)
                return NotFound();

            return Ok(updatedStudent);
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteStudentAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}