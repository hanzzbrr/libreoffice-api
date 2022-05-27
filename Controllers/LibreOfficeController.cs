using Microsoft.AspNetCore.Mvc;
using LibreOfficeLibrary;

namespace LibreOfficeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LibreOfficeController : ControllerBase
{
    [HttpGet(Name = "ConvertPdf")]
    public object Get()
    {
        DocumentConverter converter = new DocumentConverter();
        converter.ConvertToPdf("input.docx", "target.pdf");
        return "converted";
    }
}