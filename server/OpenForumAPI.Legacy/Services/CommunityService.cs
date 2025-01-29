using Microsoft.EntityFrameworkCore;
using OpenForumAPI.Legacy.Data;
using OpenForumAPI.Legacy.Interfaces;
using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Services;

public class CommunityService : ICommunityService
{
    private readonly AppDbContext _context;

    public CommunityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Community>> GetCommunities(int pageSize, int pageNumber)
    {
        int skipNumber = (pageNumber - 1) * pageSize;
        return await _context.Communities.Skip(skipNumber).Take(pageSize).ToListAsync();
    }
}
