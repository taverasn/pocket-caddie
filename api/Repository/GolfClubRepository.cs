using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.GolfClub;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GolfClubRepository : IGolfClubRepository
    {
        private readonly ApplicationDBContext _context;
        public GolfClubRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GolfClub> CreateAsync(GolfClub golfClubModel)
        {
            await _context.GolfClubs.AddAsync(golfClubModel);
            await _context.SaveChangesAsync();
            return golfClubModel;
        }

        public async Task<GolfClub?> DeleteAsync(int id)
        {
            var golfClubModel = await _context.GolfClubs.FirstOrDefaultAsync(g => g.Id == id);

            if(golfClubModel == null)
            {
                return null;
            }

            _context.GolfClubs.Remove(golfClubModel);
            await _context.SaveChangesAsync();

            return golfClubModel;
        }

        public async Task<List<GolfClub>> GetAllAsync(GolfClubQueryObject query)
        {
            var golfClubs = _context.GolfClubs.Include(a => a.AppUser).AsQueryable();

            if(query.golfClubType > 0)
            {
                golfClubs = golfClubs.Where(g => g.GolfClubType == query.golfClubType);
            }

            return await golfClubs.ToListAsync();
        }

        public async Task<GolfClub?> GetByIdAsync(int id)
        {
            return await _context.GolfClubs.Include(a => a.AppUser).FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<GolfClub?> UpdateAsync(int id, UpdateGolfClubRequestDto golfClubDto)
        {
            var existingGolfClub = await _context.GolfClubs.FindAsync(id);

            if(existingGolfClub == null)
            {
                return null;
            }

            existingGolfClub.Distance = golfClubDto.Distance;

            await _context.SaveChangesAsync();

            return existingGolfClub;
        }
    }
}