using Microsoft.AspNetCore.Mvc;
using LibreOfficeLibrary;

namespace LibreOfficeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LibreOfficeController : ControllerBase
{
    [HttpGet(Name = "ConvertPdf")]
    public object Get(string filePath, string targetPath)
    {
        DocumentConverter converter = new DocumentConverter();
        converter.ConvertToPdf(filePath, targetPath);
        return "converted";
    }
}