using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Dtos.GolfClub
{
    public class CreateGolfClubRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Name cannot be over 10 characters")]
        public string Name { get; set; } = String.Empty;
        [Required]
        [Range(0, 999)]
        [DefaultValue(0)]
        public int Distance { get; set; }
        [Required]
        public GolfClubType GolfClubType { get; set; }
    }
}