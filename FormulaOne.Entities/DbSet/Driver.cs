using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public class Driver : BaseEntities
    {
        public Driver()
        { 
            Achievements = new HashSet <Achievement> ();
        }

        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } =string.Empty;
        public int DriverNumber { get; set; } 

        public DateTime DateofBirth { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set;}
    }
}
