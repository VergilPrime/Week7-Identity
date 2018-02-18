using MCMultiverse.Data;
using MCMultiverse.Models.Application.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models.Application
{

    public class MCServer
    {
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Activity { get; set; }
        public int Updated { get; set; }
        public int Created { get; }
        public int LastPinged { get; set; }
        public int LastPingedOnline { get; set; }
        public string BannerSmall { get; set; }
        public string BannerLarge { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Vote> Votes { get; set; }

        public MCServer()
        {
            Created = Clock.Time();
        }
    }
}
