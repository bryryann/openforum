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
    private readonly ICommunityRepository _communityRepo;

    public CommunityController(ICommunityRepository communityRepo)
    {
        _communityRepo = communityRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CommunityQueryObject query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var communities = await _communityRepo.GetCommunities(pageSize: query.PageSize, pageNumber: query.PageNumber);

        return Ok(communities.Select(c => c.MapToResponse()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> FindCommunityById([FromRoute] int id)
    {
        var community = await _communityRepo.FindCommunity(id);
        if (community == null)
            return NotFound("Community id not found");

        return Ok(community.MapToResponse());
    }
}
