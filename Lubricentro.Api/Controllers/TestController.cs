using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubricentro.Api.Controllers;

[AllowAnonymous]
[Route("Test")]
public class TestController : ApiController
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public TestController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    [HttpPost("GetImage")]
    public IActionResult GetImage()
    {
        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "dog.jpeg");

        if (System.IO.File.Exists(imagePath))
        {
            // Return the image file as a FileStreamResult
            var imageData = System.IO.File.ReadAllBytes(imagePath);
            return Ok(imageData); // Adjust content type as needed
        }
        else
        {
            return NotFound(); // Return 404 Not Found if the image doesn't exist
        }
    }
    [HttpPost("saveimage")]
    public IActionResult SaveImage(SaveImageRequest request)
    {
        byte[] imageData = request.ImageData;
        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "dogo.jpeg");
        using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            // Write the image data to the FileStream
            stream.Write(imageData, 0, imageData.Length);
        }
        return Ok();
    }
    public record SaveImageRequest(byte[] ImageData) { };
}
