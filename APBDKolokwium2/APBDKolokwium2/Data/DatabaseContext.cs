using APBDKolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDKolokwium2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Racer>().HasData(new List<Racer>
        {
            new Racer{RacerId = 1, FirstName = "Lewis", LastName = "Hamilton"},
            new Racer{RacerId = 2, FirstName = "Robert", LastName = "Kubica"},
        });

        modelBuilder.Entity<Race>().HasData(new List<Race>
        {
            new Race{RaceId = 1,Name ="British Grand Prix",Location = "Silverstone, UK", Date = new DateTime(2025,07,14)},
            new Race{RaceId = 2,Name ="Monaco Grand Prix",Location = "Monte Carlo, Monaco", Date = new DateTime(2025,05,25)}
        });
        modelBuilder.Entity<Track>().HasData(new List<Track>
        {
            new Track{TrackId = 1,Name = "Silverstone Circuit",LenghtInKm = 5.89},
            new Track{TrackId = 2,Name = "Monaco Circuit",LenghtInKm = 3.34}
        });

        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>
        {
            new TrackRace{TrackRaceId = 1,TrackId = 1,RaceId = 1, Laps = 52},
            new TrackRace{TrackRaceId = 2,TrackId = 2,RaceId = 2, Laps = 78},
        });

        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>
        {
            new RaceParticipation{TrackRaceId = 1,RacerId = 1, FinishTimeInSeconds = 5460,Position = 1},
            new RaceParticipation{TrackRaceId = 2,RacerId = 1, FinishTimeInSeconds = 6300,Position = 2}
        });

    }
}