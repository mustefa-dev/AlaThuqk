using AlaThuqk.Respository;
using AlaThuqk.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers;

public class FileController: BaseController{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService) {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] IFormFile file) =>  Ok(await _fileService.Upload(file));
    [HttpPost("multi")]
    public async Task<IActionResult> Upload([FromForm] IFormFile[] files) => Ok(await _fileService.Upload(files));



}