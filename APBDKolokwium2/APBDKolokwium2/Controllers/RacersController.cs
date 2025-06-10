using APBDKolokwium2.Exceptions;
using APBDKolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDKolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RacersController : ControllerBase
{
    private readonly IDbService _dbService;

    public RacersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetRacersParticipations(int id)
    {
        try
        {
            var result = await _dbService.GetRacersParticipations(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
}