using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
   public class Expenditure
    {
        public int ID { get; set; }
        public string ExpenditureName { get; set; }
        public decimal ExpenditureAmount { get; set; }
        public string Details { get; set; }
        public int? EmployeeID { get; set; }
        public int? ManagerID { get; set; }

        public  virtual Employee Employee { get; set; }

        public virtual Manager Manager { get; set; }
    }
}
