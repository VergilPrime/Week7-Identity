using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCMultiverse.Models.Application.Static;

namespace MCMultiverse.Models.Application
{
    public class Vote
    {
        public int Id { get; }

        public ApplicationUser ApplicationUser { get; set; }

        public string MinecraftUserName { get; set; }

        public string IPAddress { get; set; }
        
        public MCServer MCServer { get; set; }

        public int TimeStamp { get; }

        public Vote()
        {
            TimeStamp = Clock.Time();
        }
    }
}
