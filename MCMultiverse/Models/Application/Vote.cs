using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCMultiverse.Models.Application.Static;

namespace MCMultiverse.Models.Application
{
    public class Vote
    {
        public ApplicationUser ApplicationUser { get; set; }

        public MCServer MCServer { get; set; }

        public int TimeStamp { get; }

        public Vote()
        {
            TimeStamp = Clock.Time();
        }
    }
}
