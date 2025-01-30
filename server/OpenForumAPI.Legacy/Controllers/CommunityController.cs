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

    private readonly ITokenService _tokens;

    public CommunityController(ITokenService tokens, ICommunityRepository communityRepo)
    {
        _tokens = tokens;
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

    [HttpPost("")]
    public async Task<IActionResult> CreateCommunity([FromBody] CreateCommunityRequest model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var header = _tokens.GetToken();
        if (header == null)
            return StatusCode(500);

        var userName = _tokens.GetUsernameFromToken(header);

        var newCommunity = await _communityRepo.CreateCommunity(model, userName!);
        if (newCommunity == null)
            return BadRequest();

        return Ok(newCommunity.MapToResponse());
    }
}
