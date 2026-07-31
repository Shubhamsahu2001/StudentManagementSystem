using AutoMapper;
using StudentManagement.API.DTOs.Students;
using StudentManagement.API.DTOs.Subjects;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;
using StudentManagement.API.Repositories;

namespace StudentManagement.API.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectRepository.GetAllSubjectsAsync();

            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto?> GetSubjectByIdAsync(int id)
        {
            var subject = await _subjectRepository.GetSubjectByIdAsync(id);

            if (subject == null)
                return null;

            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task<SubjectDto> AddSubjectAsync(CreateSubjectDto subjectDto)
        { 
            var subject = _mapper.Map<Subject>(subjectDto);

            var createdSubject = await _subjectRepository.AddSubjectAsync(subject);

            return _mapper.Map<SubjectDto>(createdSubject);
        }

        public async Task<SubjectDto?> UpdateSubjectAsync(UpdateSubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);

            var updatedSubject = await _subjectRepository.UpdateSubjectAsync(subject);

            if (updatedSubject == null)
                return null;

            return _mapper.Map<SubjectDto>(updatedSubject);
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            return await _subjectRepository.DeleteSubjectAsync(id);
        }
       
    }
}
