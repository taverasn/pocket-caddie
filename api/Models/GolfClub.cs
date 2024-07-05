using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("GolfClubs")]
    public class GolfClub
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        [Column(TypeName ="int(3)")]
        public int Distance { get; set; }
        public int? GolfBagId { get; set; }
        public GolfBag? GolfBag { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}