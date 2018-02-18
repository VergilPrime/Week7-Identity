﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models.Application
{
    public class Favorite
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int MCServerId { get; set; }
        public MCServer MCServer { get; set; }
        
    }
}
