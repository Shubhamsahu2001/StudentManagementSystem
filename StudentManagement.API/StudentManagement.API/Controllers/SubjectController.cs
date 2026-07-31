using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.DTOs.Subjects;
using StudentManagement.API.Interfaces;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
                return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject(CreateSubjectDto subjectDto)
        {
            var createdSubject = await _subjectService.AddSubjectAsync(subjectDto);
            return CreatedAtAction(nameof(GetSubjectById), 
                new { id = createdSubject.SubjectId }, 
                createdSubject);
            
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, UpdateSubjectDto subjectDto)
        {
                if (id != subjectDto.SubjectId)
                    return BadRequest();

                var updatedSubject = await _subjectService.UpdateSubjectAsync(subjectDto);

                if (updatedSubject == null)
                    return NotFound();

                return Ok(updatedSubject);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var isDeleted = await _subjectService.DeleteSubjectAsync(id);
            if (!isDeleted)
                return NotFound();
            return NoContent();
        }

    }
}
