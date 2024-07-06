using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GolfClub;
using api.Models;

namespace api.Mappers
{
    public static class GolfClubMapper
    {
        public static GolfClubDto ToGolfClubDto(this GolfClub golfClub)
        {
            return new GolfClubDto
            {
                Id = golfClub.Id,
                Name = golfClub.Name,
                Distance = golfClub.Distance,
                GolfClubType = golfClub.GolfClubType,
            };
        }

        public static GolfClub ToGolfClubFromCreate(this CreateGolfClubRequestDto golfClubDto)
        {
            return new GolfClub
            {
                Name = golfClubDto.Name,
                Distance = golfClubDto.Distance,
                GolfClubType = golfClubDto.GolfClubType,
            };
        }
    }
}