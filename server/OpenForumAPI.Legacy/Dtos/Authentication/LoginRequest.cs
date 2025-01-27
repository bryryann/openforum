using System.ComponentModel.DataAnnotations;

namespace OpenForumAPI.Legacy.Dtos.Authentication;

public class LoginRequest
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
}
