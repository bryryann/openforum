using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Dtos.User;

public class UserDataResponse
{
    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required List<Community> Communities { get; set; }
}
