using BackEnd.Api.Services.Abstractions;
using BackEnd.Domain.Dtos.Couriers;
using BackEnd.Infra.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourierController : ControllerBase
{

    private readonly ICourierRepository _courierRepository;
    private readonly IAmazonS3Service _service;
    private readonly IConfiguration _configuration;

    public CourierController(
        ICourierRepository courierRepository,
        IAmazonS3Service service,
        IConfiguration configuration)
    {
        _configuration = configuration;
        _service = service;
        _courierRepository = courierRepository;
    }


    [HttpGet("All")]
    public async Task<IActionResult> GetAll()
    {

        var all = await _courierRepository.Get();

        if (!all.Any())
            return Ok("No Courier found");

        return Ok(all);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateCourierDto createCourierDto)
    { 
        var createdCourier = await _courierRepository.AddAsync(createCourierDto);

        return Created(nameof(CourierController), createdCourier);

    }

    [HttpPost("LicenseDriver")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        // todo: tratar nome dos arquivos recebidos para vincular ao Entregador cadastrado

        if (file == null || file.Length == 0)
            return BadRequest("No file sent");
        
        var fileExtension = file.FileName.Split(".").ToList().LastOrDefault();
        if (!(fileExtension!.Trim() == "bmp" || fileExtension!.Trim() == "png")) return BadRequest("Invalid format file, must be png or bmp");

        string bucketName = _configuration["AWS:BucketDocs"]!;
        string keyName = file.FileName;

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            var fileData= memoryStream.ToArray();
            await _service.UploadFileAsync(bucketName, fileData, keyName);
        }

        return Ok("File sent sucessfuly");
    }


}
