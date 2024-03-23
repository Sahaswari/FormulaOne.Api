using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IUnitofWork
    {
        IDriverRepository Drivers { get; }
        IAchevementsRepository Achevements { get; }

        Task CompleteAsync();
    }
}
