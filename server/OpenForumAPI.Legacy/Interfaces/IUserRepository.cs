using OpenForumAPI.Legacy.Models;

namespace OpenForumAPI.Legacy.Interfaces;

public interface IUserRepository
{
    Task<bool> UserExists(int id);

    Task<User?> FindUser(string userName);
}
