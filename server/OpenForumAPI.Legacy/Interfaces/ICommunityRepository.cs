using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Interfaces;

public interface ICommunityRepository
{
    Task<List<Community>> GetCommunities(int pageSize, int pageNumber);
}
