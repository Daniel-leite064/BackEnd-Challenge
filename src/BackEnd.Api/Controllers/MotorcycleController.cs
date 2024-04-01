using BackEnd.Domain.Dtos.Motorcycle;
using BackEnd.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotorcycleController : ControllerBase
{

    private readonly IMotorcycleRepository _motorcycleRepository;

    public MotorcycleController(IMotorcycleRepository motorcycleRepository)
        => _motorcycleRepository = motorcycleRepository;


    [HttpGet("All")]
    public async Task<IActionResult> GetAll()
    {

        var all = await _motorcycleRepository.Get();

        if (!all.Any())
            return Ok("No motorcycles found!");

        return Ok(all);
    }

    [HttpGet("{plate}")]
    public async Task<IActionResult> FindByPlate(string plate)
    {

        var motorcycle = await _motorcycleRepository.FindByPlate(plate.Trim());
  

        return Ok(motorcycle);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateMotorcycleDto createMotorcycle)
    {

        var createdMotorcycle = await _motorcycleRepository.AddAsync(createMotorcycle);

        return Created(nameof(MotorcycleController), createdMotorcycle);

    }

    [HttpPatch("Plate/{id}")]
    public async Task<IActionResult> PatchAsync(Guid id , [FromBody] UpdateMotorcycleDto updateMotorcycleDto)
    {

        var updatedMotorcycle = await _motorcycleRepository.PatchAsync(id, updateMotorcycleDto);

        return Ok(updatedMotorcycle);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {

        var deletedMotorcycle = await _motorcycleRepository.DeleteAsync(id);

        if (deletedMotorcycle == default) return BadRequest("Motorcycle have Rental active");

        return NoContent();

    }


}
