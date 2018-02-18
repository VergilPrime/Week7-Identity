using MCMultiverse.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Services
{
    interface IMCServerService
    {
        ICollection<MCServer> GetServers(int page, int count, string filter);
    }
}
