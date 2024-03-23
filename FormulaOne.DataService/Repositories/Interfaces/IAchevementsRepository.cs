﻿using FormulaOne.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IAchevementsRepository : IGenericRepository<Achievement>
    {
        Task <Achievement> GetAchievementAsync (Guid driverId);
    }
}
