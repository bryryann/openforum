using Microsoft.EntityFrameworkCore;
using OpenForumAPI.Legacy.Data;
using OpenForumAPI.Legacy.Interfaces;
using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Repositories;

public class CommunityRepository : ICommunityRepository
{
    private readonly AppDbContext _context;

    public CommunityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Community>> GetCommunities(int pageSize, int pageNumber)
    {
        int skipNumber = (pageNumber - 1) * pageSize;
        return await _context.Communities.Skip(skipNumber).Take(pageSize).ToListAsync();
    }
}
