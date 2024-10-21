using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    [HttpPost("UpLoad"), DisableRequestSizeLimit]
    public async Task <IActionResult> UploadFile([FromForm] FileName model)
    {
        //if (model.File == null && model.File.Length == 0)
        //{
        //    return BadRequest("Invalid file");
        //}
        var folderName = Path.Combine("wwwroot", "images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //if (!Directory.Exists(pathToSave))
        //{
        //    Directory.CreateDirectory(pathToSave);
        //}
        var fileName = model.File.FileName;
        var fullPath = Path.Combine(pathToSave, fileName);
        var dbPath = Path.Combine(folderName, fileName);
        //if (System.IO.File.Exists(fullPath))
        //{
        //    return BadRequest("file already exist");
        //}
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            model.File.CopyTo(stream);
        }
        return Ok (new { dbPath });
    }
}
