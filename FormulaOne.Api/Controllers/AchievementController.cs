using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;

namespace FormulaOne.Api.Controllers
{
    public class AchievementController : BaseController
    {
        public AchievementController(IUnitofWork unitofWork, IMapper mapper) : base(unitofWork, mapper)
        {
        }
    }
}
