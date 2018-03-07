using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCMultiverse.Data;
using MCMultiverse.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MCMultiverse.Models;

namespace MCMultiverse.Controllers
{
    public class MCServersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public MCServersController(
            IAuthorizationService authorizationService,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: MCServers
        public async Task<IActionResult> Index()
        {
            return View(await _context.MCServers.ToListAsync());
        }

        // GET: MCServers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCServer = await _context.MCServers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mCServer == null)
            {
                return NotFound();
            }

            return View(mCServer);
        }

        // GET: MCServers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MCServers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Address,Activity,Updated,LastPinged,LastPingedOnline,BannerSmall,BannerSmallContentType,BannerLarge,BannerLargeContentType")] MCServer mCServer)
        {
            if (ModelState.IsValid)
            {
                var bannerSmall = mCServer.BannerSmall;
                var bannerLarge = mCServer.BannerLarge;
                mCServer.BannerSmall = null;
                mCServer.BannerLarge = null;

                ApplicationUser user = await _userManager.GetUserAsync(User);
                mCServer.Owner = user;
                _context.Add(mCServer);
                await _context.SaveChangesAsync();

                Task<MCServer> task = _context.MCServers.FirstOrDefaultAsync(server => server.Address == mCServer.Address);

                task.Wait();

                int serverId = task.Result.Id;

                //if (bannerSmall != null) {
                //    Services.AzureImageService.UploadBlob(serverId.ToString() + "_BannerSmall", bannerSmall);
                //}

                //if (bannerLarge != null)
                //{
                //    Services.AzureImageService.UploadBlob(serverId.ToString() + "_BannerLarge", bannerLarge);
                //}

                return RedirectToAction(nameof(Index));
            }
            return View(mCServer);
        }

        // GET: MCServers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var mCServer = await _context.MCServers.Include(m => m.Owner).SingleOrDefaultAsync(m => m.Id == id);

            if (id == null)
            {
                return StatusCode(300);
            }

            if (mCServer == null)
            {
                return StatusCode(300);
            }

            AuthorizationResult authResult = await _authorizationService.AuthorizeAsync(User, mCServer, "IsOwner");

            if (authResult.Succeeded)
            {
                return View(mCServer);
            }
            else
            {
                return new ForbidResult();
            }

        }

        // POST: MCServers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Address,Activity,Updated,LastPinged,LastPingedOnline,BannerSmall,BannerSmallContentType,BannerLarge,BannerLargeContentType")] MCServer mCServer)
        {
            if (id != mCServer.Id)
            {
                return NotFound();
            }

            var mCServer_ = await _context.MCServers.Include(m => m.Owner).SingleOrDefaultAsync(m => m.Id == id);

            AuthorizationResult authResult = await _authorizationService.AuthorizeAsync(User, mCServer_, "IsOwner");

            if (authResult.Succeeded)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(mCServer);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MCServerExists(mCServer.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(mCServer);
            }
            else
            {
                return new ForbidResult();
            }
        }

        // GET: MCServers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            var mCServer = await _context.MCServers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mCServer == null)
            {
                return new NotFoundResult();
            }

            AuthorizationResult authResult = await _authorizationService.AuthorizeAsync(User, mCServer, "IsOwner");

            if (authResult.Succeeded)
            {
                return View(mCServer);
            }
            else
            {
                return new ForbidResult();
            }
        }

        // POST: MCServers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mCServer = await _context.MCServers.Include(m => m.Owner).SingleOrDefaultAsync(m => m.Id == id);

            AuthorizationResult authResult = await _authorizationService.AuthorizeAsync(User, mCServer, "IsOwner");

            if (authResult.Succeeded)
            {
                _context.MCServers.Remove(mCServer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return new ForbidResult();
            }
        }

        [HttpPost, ActionName("Favorite")]
        [Authorize]
        public async Task<IActionResult> FavoriteAsync(int mCServerId)
        {
            FavoritesController favcontroller = new FavoritesController(_context, _userManager);
            await favcontroller.Create(mCServerId);

            return StatusCode(200);
        }

        private bool MCServerExists(int id)
        {
            return _context.MCServers.Any(e => e.Id == id);
        }
    }
}
