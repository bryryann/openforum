using Microsoft.EntityFrameworkCore;
using OpenForumAPI.Legacy.Data;
using OpenForumAPI.Legacy.Interfaces;
using OpenForumAPI.Legacy.Dtos.Community;
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

    public async Task<Community?> FindCommunity(int id) =>
        await _context.Communities.FindAsync(id);

    public async Task<Community?> CreateCommunity(CreateCommunityRequest communityModel)
    {
        throw new NotImplementedException("CommunityRepository.CreateCommunity() method not implemented.");
    }
}
