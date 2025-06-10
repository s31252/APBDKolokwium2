using APBDKolokwium2.DTOs;

namespace APBDKolokwium2.Services;

public interface IDbService
{
    Task<ParticipantRequestDTO> GetRacersParticipations(int id);
    Task AddParticipant(AddNewParticipantDTO participant);
}