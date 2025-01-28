using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OpenForumAPI.Legacy.Models;
using OpenForumAPI.Legacy.Interfaces;
using OpenForumAPI.Legacy.Dtos.Authentication;

namespace OpenForumAPI.Legacy.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokens;

    public AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ITokenService tokenService)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._tokens = tokenService;
    }

    [HttpGet("user")]
    [Authorize]
    public async Task<IActionResult> GetInfo()
    {
        var header = _tokens.GetToken();
        return Ok(header);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == request.Username!.ToLower());
        if (user == null)
            return Unauthorized("Invalid username/password!");

        var signAction = await _signInManager.CheckPasswordSignInAsync(user, request.Password!, false);
        if (!signAction.Succeeded)
            return Unauthorized("Invalid username/password!");

        return Ok(
            new UserResponse
            {
                UserName = user.UserName!,
                Email = user.Email!,
                Token = _tokens.CreateToken(user)
            });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var user = new User
            {
                UserName = request.Username,
                Email = request.EmailAddress
            };

            var createAction = await _userManager.CreateAsync(user, request.Password!);
            if (!createAction.Succeeded)
                return StatusCode(500, createAction.Errors);

            var roleAction = await _userManager.AddToRoleAsync(user, "User");
            if (!roleAction.Succeeded)
                return StatusCode(500, roleAction.Errors);

            return Ok(
                new UserResponse
                {
                    UserName = user.UserName!,
                    Email = user.Email!,
                    Token = _tokens.CreateToken(user)
                });
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}
