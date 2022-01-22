using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
   public class DebitVM
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string DebitName { get; set; }
        public DateTime StartedDate { get; set; }
        public bool? IsAproved { get; set; }
        public string Details { get; set; }
        public string DescofRejec { get; set; }
    }
}
