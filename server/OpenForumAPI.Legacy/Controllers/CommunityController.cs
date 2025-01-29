using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OpenForumAPI.Legacy.Interfaces;
using OpenForumAPI.Legacy.Dtos.Community;
using OpenForumAPI.Legacy.Mappers;

namespace OpenForumAPI.Legacy.Controllers;

[Route("api/communities")]
[ApiController]
[Authorize]
public class CommunityController : ControllerBase
{
    private readonly ICommunityService _communityService;

    public CommunityController(ICommunityService communityService)
    {
        _communityService = communityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CommunityQueryObject query)
    {
        var communities = await _communityService.GetCommunities(pageSize: query.PageSize, pageNumber: query.PageNumber);

        return Ok(communities.Select(c => c.MapToResponse()));
    }
}
