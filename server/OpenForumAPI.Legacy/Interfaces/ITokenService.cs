using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);

    string? GetToken();

    string? GetUsernameFromToken(string token);
}

