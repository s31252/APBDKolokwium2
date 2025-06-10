
using APBDKolokwium2.DTOs;
using APBDKolokwium2.Exceptions;
using APBDKolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDKolokwium2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Track_racesController : ControllerBase
{
    public IDbService _dbService;

    public Track_racesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("participants")]
    public async Task<IActionResult> AddNewParticipant(AddNewParticipantDTO dto)
    {
        try
        {
            await _dbService.AddParticipant(dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
}