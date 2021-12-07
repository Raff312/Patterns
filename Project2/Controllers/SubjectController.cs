using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.MongoDb.Repositories;

namespace Project2.Controllers {
    [Route("subjects")]
    public class SubjectController : Controller {

        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository) {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        public async Task<IList<Subject>> List() {
            return await _subjectRepository.ListAllAsync();
        }

        [HttpPost]
        public async Task<Subject> Create([FromBody] CreateSubjectModel model) {
            var subject = new Subject() {
                Name = model.Name,
                IsExam = model.IsExam
            };

            return await _subjectRepository.CreateAsync(subject);
        }

        [HttpGet("{subjectId:guid}")]
        public async Task<Subject?> Get(Guid subjectId) {
            var subject = await _subjectRepository.GetByIdAsync(subjectId);
            return subject;
        }

        [HttpPut("{subjectId:guid}")]
        public async Task<Subject?> Update(Guid subjectId, [FromBody] Subject model) {
            var subject = await _subjectRepository.GetByIdAsync(subjectId);
            if (subject == null) {
                return null;
            }

            subject.Update(model);
            return await _subjectRepository.UpdateAsync(subject);
        }

        [HttpDelete("{subjectId:guid}")]
        public async Task Delete(Guid subjectId) {
            var subject = await _subjectRepository.GetByIdAsync(subjectId);
            if (subject != null) {
                await _subjectRepository.DeleteAsync(subject);
            }
        }
    }
}
