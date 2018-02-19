using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCMultiverse.Models.Application;
using Microsoft.AspNetCore.Identity;

namespace MCMultiverse.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Favorite> Favorites { get; set; }

        public ICollection<MCServer> Servers { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public int TotalDonations { get; set; }

        public string MinecraftUserName { get; set; }

        public string MinecraftUUID { get; set; }
    }
}
