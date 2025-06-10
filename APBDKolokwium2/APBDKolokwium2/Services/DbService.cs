using APBDKolokwium2.Data;
using APBDKolokwium2.DTOs;
using APBDKolokwium2.Exceptions;
using APBDKolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDKolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ParticipantRequestDTO> GetRacersParticipations(int id)
    {
        var request = await _context.Racers
            .Where(r => r.RacerId == id)
            .Select(r => new ParticipantRequestDTO
            {
                RacerId = id,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Participations = r.RaceParticipations
                    .Select(p => new ParticipationDTO
                    {
                        Race = new RaceDTO
                        {
                            Name = p.TrackRace.Race.Name,
                            Location = p.TrackRace.Race.Location,
                            Date = p.TrackRace.Race.Date

                        },
                        Track = new TrackDTO()
                        {
                            Name = p.TrackRace.Track.Name,
                            LengthInKM = p.TrackRace.Track.LenghtInKm
                        },
                        Laps = p.TrackRace.Laps,
                        FinishTimeInSeconds = p.FinishTimeInSeconds,
                        Position = p.Position
                    }).ToList()

            }).FirstOrDefaultAsync();
        
        return request;
    }

    public async Task AddParticipant(AddNewParticipantDTO participant)
    {
        var race = await _context.Races
            .FirstOrDefaultAsync(r => r.Name == participant.RaceName);

        if (race is null)
        {
            throw new NotFoundException("Race not found");
        }
        
        var track = await _context.Tracks
            .FirstOrDefaultAsync(t => t.Name == participant.TrackName);
        if (track is null)
        {
           throw new NotFoundException("Track not found"); 
        }

        foreach (var racer in participant.Participations)
        {
            var ifExist = await _context.Racers.FirstOrDefaultAsync(r => r.RacerId == racer.RacerId);
            if (ifExist is null)
            {
                throw new NotFoundException("Racer not found");
            }

            var trackraceId = await _context.TrackRaces.Where(tr => tr.RaceId == racer.RacerId).Select(tr => tr.RaceId)
                .FirstOrDefaultAsync();
            
            var raceParticipation = new RaceParticipation
            {
                TrackRaceId =trackraceId,
                RacerId = racer.RacerId,
                FinishTimeInSeconds = racer.FinishTimeInSeconds,
                Position = racer.Position,
            };

            /*if (racer.FinishTimeInSeconds < _context.TrackRaces
                    .Where(tr => tr.TrackRaceId == trackraceId)
                    .Select(tr => tr.RaceId)
                    .FirstOrDefaultAsync()) ;*/
            await _context.RaceParticipations.AddAsync(raceParticipation);
            await _context.SaveChangesAsync();
        }
    }
}