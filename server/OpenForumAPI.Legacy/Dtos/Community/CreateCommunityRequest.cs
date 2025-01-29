using System.ComponentModel.DataAnnotations;

namespace OpenForumAPI.Legacy.Dtos.Community;

public class CreateCommunityRequest
{
    [Required]
    public string? Handle { get; set; }

    public string Description { get; set; } = string.Empty;
}
