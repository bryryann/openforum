using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OpenForumAPI.Legacy.Models;

[Index(nameof(Handle), IsUnique = true)]
public class Community
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(4, ErrorMessage = "Community handle too short.")]
    [MaxLength(30, ErrorMessage = "Community handle too long.")]
    public string? Handle { get; set; }

    public string? Description { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public List<User> Moderators { get; set; } = new List<User>();
}
