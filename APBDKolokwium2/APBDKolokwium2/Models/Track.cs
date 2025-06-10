﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBDKolokwium2.Models;

[Table(("Track"))]
public class Track
{
    [Key]
    public int TrackId { get; set; }
    [MaxLength(100)] 
    public string Name { get; set; }= null;
    [Column(TypeName = "decimal")]
    [Precision(5, 2)]
    public double LenghtInKm { get; set; }

    public ICollection<TrackRace> TrackRaces { get; set; } = null;
}