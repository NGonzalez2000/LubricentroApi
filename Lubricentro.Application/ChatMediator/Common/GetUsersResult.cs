namespace Lubricentro.Application.ChatMediator.Common;

public record GetUsersResult(List<UserResult> Users)
{
}

public record UserResult(byte[]? UserImageData, string Id, string UserName) { }
