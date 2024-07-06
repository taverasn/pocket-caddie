using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GolfClub;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IGolfClubRepository
    {
        Task<List<GolfClub>> GetAllAsync(GolfClubQueryObject query);
        Task<GolfClub?> GetByIdAsync(int id);
        Task<GolfClub> CreateAsync(GolfClub golfClubModel);
        Task<GolfClub?> UpdateAsync(int id, UpdateGolfClubRequestDto golfClubDto);
        Task<GolfClub?> DeleteAsync(int id);

    }
}