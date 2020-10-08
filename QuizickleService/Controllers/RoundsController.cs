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
    public class RoundsController : ControllerBase
    {
        private readonly QuizickleContext _context;
        private readonly IDataRepository<Round> _repo;

        public RoundsController(QuizickleContext context, IDataRepository<Round> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Rounds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Round>>> GetRound()
        {
            return await _context.Round.ToListAsync();
        }

        // GET: api/Rounds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Round>> GetRound(int id)
        {
            var round = await _context.Round.FindAsync(id);

            if (round == null)
            {
                return NotFound();
            }

            return round;
        }

        // PUT: api/Rounds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRound(int id, Round round)
        {
            if (id != round.Id)
            {
                return BadRequest();
            }

            _context.Entry(round).State = EntityState.Modified;

            try
            {
                _repo.Update(round);
                var save = await _repo.SaveAsync(round);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundExists(id))
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

        // POST: api/Rounds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Round>> PostRound(Round round)
        {
            _repo.Add(round);
            var save = await _repo.SaveAsync(round);

            return CreatedAtAction("GetRound", new { id = round.Id }, round);
        }

        // DELETE: api/Rounds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Round>> DeleteRound(int id)
        {
            var round = await _context.Round.FindAsync(id);
            if (round == null)
            {
                return NotFound();
            }

            _repo.Delete(round);
            var save = await _repo.SaveAsync(round);

            return round;
        }

        private bool RoundExists(int id)
        {
            return _context.Round.Any(e => e.Id == id);
        }
    }
}
