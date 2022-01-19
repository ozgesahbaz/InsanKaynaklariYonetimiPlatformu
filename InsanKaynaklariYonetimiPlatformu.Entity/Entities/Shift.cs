using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
  public  class Shift
    {
        public Shift()
        {
            Employees = new HashSet<Employee>();
            Respites = new HashSet<Respite>();
        }
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public string ShiftTimeSlot { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Respite> Respites { get; set; }
    }
}
