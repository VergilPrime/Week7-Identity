using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models.Application
{
    public class FavoriteServer
    {
        public string UserId { get; set; }
        public int FK_MCServerId { get; set; }
        public MCServer MCServer { get; set; }
    }
}
