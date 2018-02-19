using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCMultiverse.Data;
using MCMultiverse.Models.Application;
using MCMultiverse.Models.Application.Static;
using MCMultiverse.Models;
using Microsoft.AspNetCore.Identity;

namespace MCMultiverse.Controllers
{
    public class VotesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VotesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Votes
        public int Count(int MCServerId)
        {
            return _context.Votes.Where(vote => vote.MCServer.Id == MCServerId).Count();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int mCServerId, string minecraftUserName, string iPAddress)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            Vote vote = new Vote()
            {
                MCServer = _context.MCServers.FirstOrDefault(server => server.Id == mCServerId),
                MinecraftUserName = minecraftUserName,
                IPAddress = iPAddress
            };

            if(user != null)
            {
                vote.ApplicationUser = user;
            }

            _context.Votes.Add(vote);

            await _context.SaveChangesAsync();

            //TODO: Figure out where to send user (nowhere)
            return View();
        }
    }
}
