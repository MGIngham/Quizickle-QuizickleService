using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizickleService.Data;
using QuizickleService.Models;

namespace QuizickleService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizickleServiceContext _context;
        private readonly IDataRepository<Question> _repo;

        public QuestionsController(QuizickleServiceContext context, IDataRepository<Question> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions.OrderByDescending(p => p.QuestionId);
        }

        // GET: api/Questions/GetQuestionsByQuizId/{quizId}
        //https://github.com/MGIngham/Quizickle.git
        [Route("[action]/{quizId}")]
        [HttpGet]
        public IEnumerable<Question> GetQuestionsByQuizId(int quizId)
        {
            Console.WriteLine(quizId);
            var res = _context.Questions.Where(p => p.QuizId == quizId);
            return res;
            //return _context.Questions.OrderByDescending(p => p.QuestionId);
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getquestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putquestion([FromRoute] int id, [FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                _repo.Update(question);
                var save = await _repo.SaveAsync(question);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!questionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> Postquestion([FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(question);
            var save = await _repo.SaveAsync(question);

            return CreatedAtAction("Getquestion", new { id = question.QuestionId }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletequestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _repo.Delete(question);
            var save = await _repo.SaveAsync(question);

            return Ok(question);
        }

        private bool questionExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }
}
