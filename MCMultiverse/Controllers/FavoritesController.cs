using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCMultiverse.Data;
using MCMultiverse.Models.Application;
using MCMultiverse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MCMultiverse.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoritesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Favorites
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            var applicationDbContext = _context.Favorites.Include(f => f.ApplicationUser).Where(f => f.ApplicationUser == user).Include(f => f.MCServer);
            return View(await applicationDbContext.ToListAsync());
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int mCServerId)
        {
            string userId = _userManager.GetUserId(User);

            _context.Favorites.Add(new Favorite() { ApplicationUserId = userId, MCServerId = mCServerId});
            await _context.SaveChangesAsync();
            return View();
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int mCServerId)
        {
            string userId = _userManager.GetUserId(User);

            Favorite favorite = await _context.Favorites.SingleOrDefaultAsync(m => m.ApplicationUserId == userId && m.MCServerId == mCServerId);
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
