using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Interfaces;

public interface ICommunityService
{
    Task<List<Community>> GetCommunities(int pageSize, int pageNumber);
}
