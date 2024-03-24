using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
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
    }
}
