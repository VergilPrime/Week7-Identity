using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCMultiverse.Data;
using MCMultiverse.Models.Application;

namespace MCMultiverse.Services
{
    public class MCServerService : IMCServerService
    {
        private readonly ApplicationDbContext _context;

        public MCServerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<MCServer> GetServers(int page, int count, string filter)
        {
            return (ICollection<MCServer>)_context.MCServers.OrderByDescending(server => server.Updated).Skip((page - 1) * count).Take(count);
        }
    }
}