using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;

namespace FormulaOne.Api.Controllers
{
    public class DriverController : BaseController
    {
        public DriverController(IUnitofWork unitofWork, IMapper mapper) : base(unitofWork, mapper)
        {
        }
    }
}
