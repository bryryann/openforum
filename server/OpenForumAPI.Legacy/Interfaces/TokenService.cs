using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}

