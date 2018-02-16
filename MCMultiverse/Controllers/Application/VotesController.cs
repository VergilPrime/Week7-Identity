using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCMultiverse.Data;
using MCMultiverse.Models.Application;

namespace MCMultiverse.Controllers.Application
{
    [Produces("application/json")]
    [Route("api/Votes")]
    public class VotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Votes
        [HttpGet]
        public IEnumerable<Vote> GetVotes()
        {
            return _context.Votes;
        }

        // GET: api/Votes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vote = await _context.Votes.SingleOrDefaultAsync(m => m.Id == id);

            if (vote == null)
            {
                return NotFound();
            }

            return Ok(vote);
        }

        // PUT: api/Votes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVote([FromRoute] int id, [FromBody] Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vote.Id)
            {
                return BadRequest();
            }

            _context.Entry(vote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(id))
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

        // POST: api/Votes
        [HttpPost]
        public async Task<IActionResult> PostVote([FromBody] Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVote", new { id = vote.Id }, vote);
        }

        // DELETE: api/Votes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vote = await _context.Votes.SingleOrDefaultAsync(m => m.Id == id);
            if (vote == null)
            {
                return NotFound();
            }

            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();

            return Ok(vote);
        }

        private bool VoteExists(int id)
        {
            return _context.Votes.Any(e => e.Id == id);
        }
    }
}