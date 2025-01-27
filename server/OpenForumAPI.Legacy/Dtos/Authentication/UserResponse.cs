namespace OpenForumAPI.Legacy.Dtos.Authentication;

public class UserResponse
{
    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string Token { get; set; }
}
