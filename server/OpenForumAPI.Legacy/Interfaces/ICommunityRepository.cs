using OpenForumAPI.Legacy.Models;
using OpenForumAPI.Legacy.Dtos.Community;

namespace OpenForumAPI.Legacy.Interfaces;

public interface ICommunityRepository
{
    Task<List<Community>> GetCommunities(int pageSize, int pageNumber);

    Task<Community?> FindCommunity(int id);

    Task<Community?> CreateCommunity(CreateCommunityRequest communityModel, string userName);

    Task<bool> CommunityExists(string handle);
}
