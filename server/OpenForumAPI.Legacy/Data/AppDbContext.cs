using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
