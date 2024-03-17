using Microsoft.AspNetCore.Http;

namespace Lubricentro.Application.Common.Interfaces.Services;

public interface IImageService
{
    string SaveImage(byte[] file);
    byte[]? GetImage(string imageName);
    void DeleteImage(string imageName);
}
