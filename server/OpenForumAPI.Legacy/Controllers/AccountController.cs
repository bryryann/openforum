using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
    }
}
