namespace APBDKolokwium2.DTOs;

public class AddNewParticipantDTO
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public List<NewParticipationDTO> Participations { get; set; }
}

public class NewParticipationDTO
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}