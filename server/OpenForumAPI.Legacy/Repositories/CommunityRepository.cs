using Microsoft.EntityFrameworkCore;
using OpenForumAPI.Legacy.Data;
using OpenForumAPI.Legacy.Interfaces;
using OpenForumAPI.Legacy.Dtos.Community;
using OpenForumAPI.Legacy.Mappers;
using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Repositories;

public class CommunityRepository : ICommunityRepository
{
    private readonly AppDbContext _context;

    private readonly IUserRepository _userRepo;

    public CommunityRepository(AppDbContext context, IUserRepository userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    public async Task<List<Community>> GetCommunities(int pageSize, int pageNumber)
    {
        int skipNumber = (pageNumber - 1) * pageSize;
        return await _context.Communities.Skip(skipNumber).Take(pageSize).ToListAsync();
    }

    public async Task<Community?> FindCommunity(int id) =>
        await _context.Communities.FindAsync(id);

    public async Task<Community?> CreateCommunity(CreateCommunityRequest communityModel, string userName)
    {
        if (await this.CommunityExists(communityModel.Handle!))
            return null;

        var creator = await _userRepo.FindUser(userName);
        if (creator == null)
            return null;

        var newCommunity = communityModel.NewCommunity(creator);

        await _context.Communities.AddAsync(newCommunity);
        await _context.SaveChangesAsync();

        return newCommunity;
    }

    public async Task<bool> CommunityExists(string handle) =>
        await _context.Communities.FirstOrDefaultAsync(c => c.Handle == handle) != null;
}
