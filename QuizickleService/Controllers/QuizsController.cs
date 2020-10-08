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
    [Route("api/[controller]")]
    [ApiController]
    public class QuizsController : ControllerBase
    {
        private readonly QuizickleContext _context;
        private readonly IDataRepository<Quiz> _repo;

        public QuizsController(QuizickleContext context, IDataRepository<Quiz> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Quizs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuiz()
        {
            return await _context.Quiz.ToListAsync();
        }

        // GET: api/Quizs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int id)
        {
            var quiz = await _context.Quiz.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return quiz;
        }

        // PUT: api/Quizs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(int id, Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                _repo.Update(quiz);
                var save = await _repo.SaveAsync(quiz);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
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

        // POST: api/Quizs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Quiz>> PostQuiz(Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(quiz);
            var save = await _repo.SaveAsync(quiz);

            return CreatedAtAction("GetQuiz", new { id = quiz.Id }, quiz);
        }

        // DELETE: api/Quizs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quiz>> DeleteQuiz(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _repo.Delete(quiz);
            var save = await _repo.SaveAsync(quiz);

            return Ok(quiz);
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.Id == id);
        }
    }
}
