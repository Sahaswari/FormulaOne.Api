using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Responses
{
    public class GetDriverResponse
    {
        public Guid DriverId { get; set; }
        public string FullName { get; set; } = string.Empty;

        public int DriverNummber { get; set; }

        public DateTime DateofBirth { get; set; }
    }
}
