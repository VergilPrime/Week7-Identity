using MCMultiverse.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Services
{
    public interface IMCServerService
    {
        IQueryable<MCServer> GetServers(int page, int count, string filter);
    }
}
