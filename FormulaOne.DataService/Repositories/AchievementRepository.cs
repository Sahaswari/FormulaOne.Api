﻿using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories
{
    public class AchievementRepository : GenericRepository<Achievement>, IAchevementsRepository
    {
        public AchievementRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);

            }
            catch (Exception e) 
            {
                _logger.LogError(e, "{Repo} GetDriverAchievementAsync function error", typeof(AchievementRepository));
                throw;
            }
        }

        async Task<Achievement> IAchevementsRepository.GetAchievementAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetDriverAchievementAsync function error", typeof(AchievementRepository));
                throw;
            }
        }

        public async Task<IEnumerable<Achievement>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(AchievementRepository));
                throw;

            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                //get my entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete function error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Achievement achievement)
        {
            try
            {
                //get my entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.PolePosition = achievement.PolePosition;
                result.FastestLap = achievement.FastestLap;
                result.WorldChampionship = achievement.WorldChampionship;
                result.RaceWins = achievement.RaceWins;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Update function error", typeof(DriverRepository));
                throw;
            }
        
    }
}
}
