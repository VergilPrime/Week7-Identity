using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCMultiverse.Data;
using MCMultiverse.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MCMultiverse.Models;

namespace MCMultiverse.Controllers.Application
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/MCServers")]
    public class MCServersController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _user;

        public MCServersController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        // GET: api/MCServers
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<MCServer> GetMCServers()
        {
            return _context.MCServers;
        }

        // GET: api/MCServers/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMCServer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mCServer = await _context.MCServers.SingleOrDefaultAsync(m => m.Id == id);

            if (mCServer == null)
            {
                return NotFound();
            }

            return Ok(mCServer);
        }

        // PUT: api/MCServers/5
        [Authorize(Roles = "Admin", Policy = "OwnsServerRequirement")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCServer([FromRoute] int id, [FromBody] MCServer mCServer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mCServer.Id)
            {
                return BadRequest();
            }

            _context.Entry(mCServer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCServerExists(id))
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

        // POST: api/MCServers
        [HttpPost]
        public async Task<IActionResult> PostMCServer([FromBody] MCServer mCServer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MCServers.Add(mCServer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCServer", new { id = mCServer.Id }, mCServer);
        }

        // DELETE: api/MCServers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCServer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mCServer = await _context.MCServers.SingleOrDefaultAsync(m => m.Id == id);
            if (mCServer == null)
            {
                return NotFound();
            }

            _context.MCServers.Remove(mCServer);
            await _context.SaveChangesAsync();

            return Ok(mCServer);
        }

        private bool MCServerExists(int id)
        {
            return _context.MCServers.Any(e => e.Id == id);
        }
    }
}