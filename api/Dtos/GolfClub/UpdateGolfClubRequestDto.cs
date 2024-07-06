using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.GolfClub
{
    public class UpdateGolfClubRequestDto
    {
        [Required]
        [Range(0, 999)]
        [DefaultValue(0)]
        public int Distance { get; set; }
    }
}