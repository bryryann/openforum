using OpenForumAPI.Legacy.Dtos.Community;
using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Mappers;

public static class CommunityMapper
{
    public static CommunityResponse MapToResponse(this Community community) =>
        new CommunityResponse
        {
            Id = community.Id,
            Handle = community.Handle!,
            Description = community.Description
        };
}
