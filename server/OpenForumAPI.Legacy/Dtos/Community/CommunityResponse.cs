namespace OpenForumAPI.Legacy.Dtos.Community;

public class CommunityResponse
{
    public int Id { get; set; }

    public string Handle { get; set; } = string.Empty;

    public string? Description { get; set; }
}
