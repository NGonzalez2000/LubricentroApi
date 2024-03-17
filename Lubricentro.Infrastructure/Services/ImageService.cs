using Lubricentro.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Lubricentro.Infrastructure.Services;

internal class ImageService : IImageService
{
    private readonly string imageFolderPath;
    public ImageService(IWebHostEnvironment webHostEnvironment)
    {
        imageFolderPath = webHostEnvironment.WebRootPath + "/images/";
    }
    public void DeleteImage(string imageName)
    {
        string imagePath = imageFolderPath + imageName;
        // Check if file exists
        if (File.Exists(imagePath))
        {
            // Delete the file
            File.Delete(imagePath);
        }
    }

    public byte[]? GetImage(string imageName)
    {
        string imagePath = imageFolderPath + imageName;

        if (!File.Exists(imagePath))
        {
            return null;
        }
        return File.ReadAllBytes(imagePath);
    }

    public string SaveImage(byte[] imageData)
    {
        string imageName = Guid.NewGuid().ToString();
        string imagePath = imageFolderPath + imageName;

        using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            // Write the image data to the FileStream
            stream.Write(imageData, 0, imageData.Length);
        }

        return imageName;
    }
}
