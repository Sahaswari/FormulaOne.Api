using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    public class DriverController : BaseController
    {
        public DriverController(IUnitofWork unitofWork, IMapper mapper) : base(unitofWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var driver = await _unitofWork.Drivers.GetById(driverId);

            if(driver == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetDriverResponse>(driver);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _mapper.Map<Driver>(driver);
            await _unitofWork.Drivers.Add(result);
            await _unitofWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new {driverId = result.Id}, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdatedDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _mapper.Map<Driver>(driver);

            await _unitofWork.Drivers.Add(result);
            await _unitofWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var driver = await _unitofWork.Drivers.All;

            return Ok(_mapper.Map<IEnumerable<GetDriverResponse>>(driver));
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task <IActionResult>DeleteDriver (Guid driverId)
        {
            var driver = await _unitofWork.Drivers.GetById(driverId);

            if(driver == null)
            {
                return NotFound();
            }
            await _unitofWork.Drivers.Delete(driverId);
            await _unitofWork.CompleteAsync();

            return NoContent();
        }

    }
}
