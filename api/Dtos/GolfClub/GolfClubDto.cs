using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api.Enums;
using Newtonsoft.Json.Converters;

namespace api.Dtos.GolfClub
{
    public class GolfClubDto
    {
        public int Id { get; set; }
        public int Distance;
        public string Name { get; set; } = String.Empty;
        [JsonConverter(typeof(StringEnumConverter))]
        public GolfClubType GolfClubType { get; set; }
        
    }
}