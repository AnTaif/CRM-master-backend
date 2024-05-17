using MasterCRM.Application.Services.User;
using MasterCRM.Application.Services.User.Responses;
using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.MapExtensions;

public static class MasterExtensions
{
    public static UserDto ToDto(this Master user)
    {
        return new UserDto
        {
            Id = user.Id,
            FullName = user.GetFullName(),
            Email = user.Email!,
            Phone = user.PhoneNumber!,
            VkLink = user.VkLink,
            TelegramLink = user.TelegramLink,
            VkId = user.VkId?.ToString()
        };
    }
}