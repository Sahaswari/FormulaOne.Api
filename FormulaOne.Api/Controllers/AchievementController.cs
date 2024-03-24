using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    public class AchievementController : BaseController
    {
        public AchievementController(
            IUnitofWork unitofWork, 
            IMapper mapper) : base(unitofWork, mapper)
        {
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            var driverAchievements = await _unitofWork.Achevements.GetAchievementAsync(driverId);

            if(driverAchievements == null)
            {
                return NotFound("Achievements not found");
            }

            var result = _mapper.Map<DriverAchievementResponse>(driverAchievements); 
            return Ok(result);
        }

        [HttpPost]
        public async Task <IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Achievement>(achievement);

            await _unitofWork.Achevements.Add(result);
            await _unitofWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchievements), 
                new {driverId = result.DriverId}
                ,result);

        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest achievement)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Achievement>(achievement);

            await _unitofWork.Achevements.Update(result);
            await _unitofWork.CompleteAsync();

            return NoContent();
        }
    }
}
