using Microsoft.EntityFrameworkCore;
using OpenForumAPI.Legacy.Data;
using OpenForumAPI.Legacy.Models;
using OpenForumAPI.Legacy.Interfaces;

namespace OpenForumAPI.Legacy.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> UserExists(int id) =>
        await _context.Users.FindAsync(id) != null;

    public async Task<User?> FindUser(string userName) =>
        await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
}
