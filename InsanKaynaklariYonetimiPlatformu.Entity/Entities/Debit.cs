using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
  public class Debit
    {
        public int ID { get; set; }
        public string DebitName { get; set; }
        public DateTime StartedDate { get; set; }
        public bool IsAproved { get; set; }
        public string Details { get; set; }
        public string DescofRejec { get; set; } //personel zimmeti reddettiğinde  sebebini  yöneticisine bildirmek için kullanacak
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
