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

        public Task AddComment(int serverId, string text)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(int commentId, string text)
        {
            throw new NotImplementedException();
        }

        public Task AddToFavorites(int serverId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetComments(int serverId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MCServer> GetFavorites()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Image> GetImages(int serverId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MCServer> GetServers(int page, int count, string filter)
        {
            return _context.MCServers.OrderByDescending(server => server.Updated).Skip((page - 1) * count).Take(count);
        }

        public int LastVoted(int serverId)
        {
            throw new NotImplementedException();
        }

        public int LastVotedIP(int serverId, string iPAddress)
        {
            throw new NotImplementedException();
        }

        public int LastVotedMCU(int serverId, string minecraftUserName)
        {
            throw new NotImplementedException();
        }

        public Task PostImage(int serverId, byte[] image)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromFavorites(int serverId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task Vote(int serverId, string minecraftUserName, string iPAddress)
        {
            throw new NotImplementedException();
        }
    }
}