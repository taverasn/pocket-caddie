using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api.Enums;

namespace api.Models
{
    [Table("GolfClubs")]
    public class GolfClub
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Distance { get; set; }
        public GolfClubType GolfClubType { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}