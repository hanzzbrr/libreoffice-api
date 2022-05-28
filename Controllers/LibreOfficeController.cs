using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibreOfficeLibrary;

namespace LibreOfficeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LibreOfficeController : ControllerBase
{
    private readonly string _input = "input.docx";
    private readonly string _output = "output.pdf";
    private readonly ILogger<LibreOfficeController> _logger;

    public LibreOfficeController(ILogger<LibreOfficeController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "ConvertPdf")]
    public ActionResult Get(IFormFile file)
    {                
        _logger.LogInformation($"Convert docx to pdf, {System.DateTime.Now}");
        _logger.LogInformation($"Read input file: {_input}");
        using (Stream fileStream = new FileStream(_input, FileMode.Create)) 
        {
            file.CopyTo(fileStream);            
        }     
        _logger.LogInformation("Read success");

        _logger.LogInformation("Start converting");
        DocumentConverter converter = new DocumentConverter();        
        converter.ConvertToPdf(_input, _output);   

        _logger.LogInformation("Convert success");

        byte[] bytes = System.IO.File.ReadAllBytes(_output);
        System.IO.File.Delete(_input);
        System.IO.File.Delete(_output);
        return File(bytes, "application/pdf", "download.pdf");
    }
}