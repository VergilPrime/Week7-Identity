using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MCMultiverse.Data;
using MCMultiverse.Models.Application;
using Microsoft.AspNetCore.Identity;

namespace MCMultiverse.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationDbContext _context { get; }

        public List<FavoriteServer> Favorites { get; set; }

        public ApplicationUser(ApplicationDbContext context)
        {
            _context = context;

            Favorites = _context.Favorites.Where(favorite => favorite.UserId == Id).ToList();
        }
    }
}
