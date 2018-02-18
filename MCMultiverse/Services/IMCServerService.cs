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

        IQueryable<MCServer> GetFavorites();
        Task AddToFavorites(int serverId);
        Task RemoveFromFavorites(int serverId);


        IQueryable<Comment> GetComments(int serverId);
        Task AddComment(int serverId, string text);
        Task AddReply(int commentId, string text);

        IQueryable<Image> GetImages(int serverId);
        Task PostImage(int serverId, byte[] image);
        Task RemoveImage(int imageId);

        Task Vote(int serverId, string minecraftUserName, string iPAddress);
        int LastVoted(int serverId);
        int LastVotedMCU(int serverId, string minecraftUserName);
        int LastVotedIP(int serverId, string iPAddress);
    }
}
