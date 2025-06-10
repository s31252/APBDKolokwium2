﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDKolokwium2.Models;
[Table("Race")]
public class Race
{
    [Key]
    public int RaceId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Location { get; set; }
    public DateTime Date { get; set; }
}