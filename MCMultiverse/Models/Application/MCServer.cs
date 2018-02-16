using MCMultiverse.Data;
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
        public string Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Votes { get; set; }
        public int Activity { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastPinged { get; set; }
        public DateTime LastPingedOnline { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
