using FormulaOne.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> All { get; }

        Task <T?> GetById(Guid id);
        Task <bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<Achievement> GetDriverAchievementAsync(Guid driverId);
    }
}
