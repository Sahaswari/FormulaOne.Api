using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class UnitofWork: IUnitofWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IDriverRepository Drivers {  get; }

        public IAchevementsRepository Achevements {  get; }

        public UnitofWork(AppDbContext context,ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("Logs");

            Drivers = new DriverRepository(_context, logger);
            Achevements = new AchievementRepository(_context, logger);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
