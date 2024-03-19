﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public class Achievement :BaseEntities
    {
        public int RaceWins { get; set; }

        public int PolePosition { get; set; }

        public int Fastestlap { get; set; }

        public int worldChampionship { get; set; }
        public Guid DriverId { get; set; }

        public virtual Driver? Driver { get; set; }

    }
}