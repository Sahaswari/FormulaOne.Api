using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public class BaseEntities //basic defines, common variables
    {
        public Guid Id { get; set; } = Guid.NewGuid(); //initializze it as newGuid
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateedDate { get; set; } = DateTime.UtcNow;
        public int Status { get; set; }
    }
}
