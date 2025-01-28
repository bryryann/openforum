using Microsoft.AspNetCore.Identity;

namespace OpenForumAPI.Legacy.Models;

public class User : IdentityUser
{
    public List<Community> Communities { get; set; } = new List<Community>();
}
