using OpenForumAPI.Legacy.Models;
using OpenForumAPI.Legacy.Dtos.User;

namespace OpenForumAPI.Legacy.Mappers;

public static class UserMapper
{
    public static UserDataResponse MapUserToUserData(User user)
        => new UserDataResponse
        {
            UserName = user.UserName!,
            Email = user.Email!,
            Communities = user.Communities
        };
}

