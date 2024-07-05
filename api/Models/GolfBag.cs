using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class GolfBag
    {
        public int Id { get; set; }
        public List<GolfClub> GolfClubs { get; set; } = new List<GolfClub>();
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}