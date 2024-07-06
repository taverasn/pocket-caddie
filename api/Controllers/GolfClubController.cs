using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GolfClub;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers
{
    [Route("api/golfclub")]
    [ApiController]
    public class GolfClubController : ControllerBase
    {
        private readonly IGolfClubRepository _golfClubRepo;
        private readonly UserManager<AppUser> _userManager;

        public GolfClubController(IGolfClubRepository golfClubRepo, UserManager<AppUser> userManager)
        {
            _golfClubRepo = golfClubRepo;
            _userManager = userManager;

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] GolfClubQueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var golfClubs = await _golfClubRepo.GetAllAsync(query);
            var golfClubDtos = golfClubs.Select(g => g.ToGolfClubDto()).ToList();

            return Ok(golfClubDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var golfClub = await _golfClubRepo.GetByIdAsync(id);

            if(golfClub == null)
            {
                return NotFound();
            }

            return Ok(golfClub.ToGolfClubDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGolfClubRequestDto golfClubDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var golfClubModel = golfClubDto.ToGolfClubFromCreate();
            golfClubModel.AppUserId = appUser.Id;

            await _golfClubRepo.CreateAsync(golfClubModel);
            return CreatedAtAction(nameof(GetById), new { id = golfClubModel.Id }, golfClubModel.ToGolfClubDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var golfClubModel = await _golfClubRepo.DeleteAsync(id);

            if(golfClubModel == null)
            {
                return NotFound("Golf Club does not exist");
            }

            return NoContent();
        }

        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGolfClubRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var golfBagModel = await _golfClubRepo.UpdateAsync(id, updateDto);

            if(golfBagModel == null)
            {
                return NotFound("Golf Bag not found");
            }
            
            return Ok(golfBagModel.ToGolfClubDto());
        }
    }
}