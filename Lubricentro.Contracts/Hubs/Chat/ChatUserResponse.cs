namespace Lubricentro.Contracts.Hubs.Chat;


public record ChatUserResponse(byte[]? UserImageData, string Id, string UserName);
